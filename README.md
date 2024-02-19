# Alice.NET

.NET библиотека для лёгкого и быстрого создания навыков для Алисы от Яндекса. Она уже содержит простенький веб-сервер.

## Как использовать

Нужно создать класс, который наследуется от класса `AliceServerBase` и переопределить метод `HandleRequest`. 
В этом методе нужно обработать запрос и вернуть ответ. Теперь нужно создать экземпляр класса, указав конструкторы
на локальный endpoint и вызвать метод `Start()`.

```csharp
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
```

Можно и просто использовать библиотеку для сериализации и десериализации запросов и ответов. Для этого используется `System.Text.Json`.

Библотека явно ориентирована на русскоязычых разработчиков, поэтому все комментарии и документация на русском языке.

## Поддержать

* [Buy Me A Coffee](https://www.buymeacoffee.com/cluster)
* [Donation Alerts](https://www.donationalerts.com/r/clustermeerkat)
* [Boosty](https://boosty.to/cluster)
