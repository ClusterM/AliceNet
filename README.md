# Alice.NET

.NET библиотека для лёгкого и быстрого создания навыков для Алисы от Яндекса. Она уже содержит простенький веб-сервер.

## Как использовать

Автоматически собранная документация тут: https://clusterm.github.io/AliceNet/

Нужно создать класс, который наследуется от класса `AliceServerBase` и переопределить метод `HandleRequest`. 
В этом методе нужно обработать запрос и вернуть ответ. Теперь нужно создать экземпляр класса, указав конструкторы
на локальный endpoint и вызвать метод `Start()`.

```csharp
using wtf.cluster.AliceNet;
using wtf.cluster.AliceNet.Types;
using wtf.cluster.AliceNet.Types.Request.Entities;
using wtf.cluster.AliceNet.Types.Request.RequestBody;
using wtf.cluster.AliceNet.Types.Response;

namespace AliceExample
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var server = new AliceServer("http://localhost:8080/alice/");
            server.Start();
            await Task.Delay(Timeout.InfiniteTimeSpan);
        }
    }

    internal class AliceServer(string localEndpoint) : AliceServerBase(localEndpoint, logger: null)
    {
        protected override async Task<AliceResponse> HandleRequest(AliceReqest request, CancellationToken cancellationToken = default)
        {
            if (request.Session.New)
            {
                return new AliceResponse
                {
                    Response = new ResponseBody
                    {
                        Text = "Привет, это Алиса! Скажи триста!",
                        Buttons = [
                                new Button
                                {
                                    Title = "Открыть репозиторий",
                                    Url = "https://github.com/ClusterM/AliceNet"
                                }
                            ]
                    }
                };
            }
            else if (request.RequestBody is SimpleUtterance su && su.Nlu.Entities.Any(e => e is NumberEntity n && n.Value == 300))
            {
                return new AliceResponse
                {
                    Response = new ResponseBody
                    {
                        Text = "Отсоси у тракториста!",
                        Tts = "xxx <[schwa t s schwa  ss ii]> у тракториста! <speaker audio=\"alice-sounds-game-win-1.opus\">"
                    }
                };
            }
            else
            {
                return new AliceResponse
                {
                    Response = new ResponseBody
                    {
                        Text = "Ну скажи триста..."
                    }
                };
            }
        }
    }
}
```

Можно и просто использовать библиотеку для сериализации и десериализации запросов и ответов. Для этого используется `System.Text.Json`.

Библотека явно ориентирована на русскоязычых разработчиков, поэтому все комментарии и документация на русском языке.

## Поддержать

* [Buy Me A Coffee](https://www.buymeacoffee.com/cluster)
* [Donation Alerts](https://www.donationalerts.com/r/clustermeerkat)
* [Boosty](https://boosty.to/cluster)
