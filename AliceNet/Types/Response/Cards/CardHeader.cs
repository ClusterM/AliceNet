using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Cards
{
    /// <summary>
    /// Заголовок списка изображений.
    /// </summary>
    public class CardHeader
    {
        /// <summary>
        /// Текст заголовка.
        /// Максимум 64 символа.
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта CardHeader.
        /// </summary>
        /// <returns>Строковое представление объекта CardHeader.</returns>
        public override string ToString() => Text;
    }
}
