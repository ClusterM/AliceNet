using wtf.cluster.AliceNet;
using wtf.cluster.AliceNet.Types;
using wtf.cluster.AliceNet.Types.Response;

namespace AliceExample
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            var server = new AliceServer("http://localhost:8080");
            server.Start();
            await Task.Delay(Timeout.InfiniteTimeSpan);
        }
    }

    internal class AliceServer(string localEndpoint) : AliceServerBase(localEndpoint)
    {
        protected override Task<AliceResponse> HandleRequest(AliceReqest reqest,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(
                new AliceResponse
                {
                    Response = new ResponseBody
                    {
                        Text = "Привет, это Алиса!",
                        Buttons = [
                            new Button
                            {
                                Title = "Открыть репозиторий",
                                Url = "https://github.com/ClusterM/AliceNet"
                            }
                        ]
                    }
                }
            );
        }
    }
}
