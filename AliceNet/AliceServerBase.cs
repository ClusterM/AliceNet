using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using wtf.cluster.AliceNet.Types;
using wtf.cluster.AliceNet.Types.Request.RequestBody;
using wtf.cluster.AliceNet.Types.Response;

namespace wtf.cluster.AliceNet
{
    /// <summary>
    /// Базовый класс для сервера Алисы.
    /// </summary>
    public abstract class AliceServerBase : IDisposable
    {
        /// <summary>
        /// Максимальное количество одновременных запросов.
        /// </summary>
        public uint MaxConcurrentRequests
        {
            get => maxConcurrentRequests; set
            {
                if (semaphore != null)
                    throw new InvalidOperationException("Can't change MaxConcurrentRequests while running");
                maxConcurrentRequests = value;
            }
        }

        private SemaphoreSlim? semaphore = null;
        private CancellationTokenSource? cancellationTokenSource = null;
        private HttpListener? callbackListener;
        private uint maxConcurrentRequests = 50;
        private string localEndpoint;

        /// <summary>
        /// Конструктор объекта AliceServerBase.
        /// </summary>
        /// <param name="localEndpoint">Локальные IP/host и порт, на которых будем принимать подключения.</param>
        public AliceServerBase(string localEndpoint)
        {
            this.localEndpoint = localEndpoint;
        }

        /// <summary>
        /// Запускает сервер.
        /// </summary>
        public void Start()
        {
            Stop();
            callbackListener ??= new HttpListener();
            callbackListener.Prefixes.Add(localEndpoint);
            callbackListener.Start();
            semaphore = new SemaphoreSlim((int)MaxConcurrentRequests);
            cancellationTokenSource = new CancellationTokenSource();
            new Task(async () => await MainLoopAsync(cancellationTokenSource.Token)).Start();
        }

        /// <summary>
        /// Останавливает сервер.
        /// </summary>
        public void Stop()
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = null;
            callbackListener?.Stop();
            callbackListener = null;
            semaphore?.Dispose();
            semaphore = null;
        }

        private async Task MainLoopAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (semaphore == null) return;
                    if (callbackListener == null) return;
                    await semaphore.WaitAsync(cancellationToken);
                    try
                    {
                        HttpListenerContext context = await callbackListener.GetContextAsync();
                        new Task(async () =>
                        {
                            try
                            {
                                await HandleRequest(context);
                            }
                            finally
                            {
                                semaphore.Release();
                            }
                        }).Start();
                    }
                    catch (HttpListenerException)
                    {
                        // Stopped?
                        if (!callbackListener?.IsListening != true)
                            return;
                        throw;
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                // TODO: some logs?
            }
        }

        private async Task HandleRequest(HttpListenerContext context)
        {
            // TODO: some logging?
            string responseBody = string.Empty;
            var request = context.Request;
            var response = context.Response;
            if (callbackListener == null) return;
            if (request == null) return;
            if (request.Url == null) return;

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };

            try
            {
                if (request.HttpMethod != "POST")
                {
                    response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                    return;
                }
                var requestText = new StreamReader(request.InputStream).ReadToEnd();
                var aliceRequest = JsonSerializer.Deserialize<AliceReqest>(requestText, jsonOptions)!;

                if (aliceRequest.RequestBody is SimpleUtterance u && u.OriginalUtterance == "ping")
                {
                    responseBody = JsonSerializer.Serialize(new AliceResponse
                    {
                        Response = new AliceResponseBody
                        {
                            Text = "pong",
                            Tts = "pong",
                            EndSession = true
                        }
                    }, jsonOptions);
                    response.ContentType = "application/json";
                    return;
                }

                var aliceResponse = await HandleRequest(aliceRequest);
                responseBody = JsonSerializer.Serialize(aliceResponse, jsonOptions);
                response.ContentType = "application/json";
            }
            catch (Exception ex)
            {
                if (ex is JsonException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseBody = "Can't parse request";
                    return;
                }
                if (context != null)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseBody = $"Error: {ex.Message}";
                    throw;
                }
            }
            finally
            {
                try
                {
                    if (context != null)
                    {
                        if (!String.IsNullOrEmpty(responseBody) && context.Response.OutputStream.CanWrite)
                        {
                            var data = Encoding.UTF8.GetBytes(responseBody);
                            context.Response.ContentLength64 = data.Length;
                            await context.Response.OutputStream.WriteAsync(data).ConfigureAwait(false);
                        }
                        try
                        {
                            // Ignore in case of error
                            context.Response.OutputStream.Close();
                        }
                        catch { }
                    }
                }
                catch (Exception)
                {
                    // TODO: some logs?
                }
            }
        }

        /// <summary>
        /// Обрабатывает запрос Алисы.
        /// </summary>
        /// <param name="reqest">Запрос Алисы.</param>
        /// <param name="cancellationToken">Токен для отмены.</param>
        /// <returns>Нужно вернуть ответ Алисе.</returns>
        protected abstract Task<AliceResponse> HandleRequest(AliceReqest reqest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Disposes of the current instance by stopping its operation.
        /// </summary>
        public void Dispose()
        {
            Stop();
        }
    }
}
