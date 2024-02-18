using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Cards
{
    /// <summary>
    /// Свойства кликабельного изображения.
    /// </summary>
    public class CardButton
    {
        /// <summary>
        /// Текст, который будет отправлен навыку по нажатию на изображение в качестве команды пользователя.
        /// Максимум 64 символа.
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        /// <summary>
        /// URL, который должен открываться по нажатию изображения.
        /// Максимум 1024 байта.
        /// </summary>
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        /// <summary>
        /// Произвольный JSON-объект, который Яндекс Диалоги должны отправить обработчику, если пользователь нажмет изображение.
        /// </summary>
        [JsonPropertyName("payload")]
        public object? Payload { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта CardButton.
        /// </summary>
        /// <returns>Строковое представление объекта CardButton.</returns>
        public override string ToString() => Text;
    }
}
