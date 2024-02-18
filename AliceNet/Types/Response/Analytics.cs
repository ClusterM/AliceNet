using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response
{
    /// <summary>
    /// Объект с данными для аналитики.
    /// Доступен навыкам с подключенным параметром Настройки AppMetrica. 
    /// Подробнее: https://yandex.ru/dev/dialogs/alice/doc/appmetrica.html
    /// </summary>
    public class Analytics
    {
        /// <summary>
        /// Массив событий.
        /// </summary>
        [JsonPropertyName("events")]
        public Event[]? Events { get; set; }
    }
}
