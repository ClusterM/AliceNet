using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response
{
    /// <summary>
    /// Кнопки, которые следует показать пользователю.
    /// </summary>
    public class Button
    {
        /// <summary>
        /// Текст кнопки.
        /// </summary>
        [JsonPropertyName("title")]
        public required string Title { get; set; }

        /// <summary>
        /// URL, который должна открывать кнопка.
        /// Максимум 1024 байта.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Произвольный JSON-объект, который Яндекс Диалоги должны отправить обработчику, если данная кнопка будет нажата.
        /// Максимум 4096 байт.
        /// </summary>
        [JsonPropertyName("payload")]
        public object? Payload { get; set; }

        /// <summary>
        /// Признак того, что кнопку нужно убрать после следующей реплики пользователя.
        /// </summary>
        [JsonPropertyName("hide")]
        public bool Hide { get; set; } = false;

        /// <summary>
        /// Возвращает строковое представление объекта Button.
        /// </summary>
        /// <returns>Строковое представление объекта Button.</returns>
        public override string ToString() => Title;
    }
}
