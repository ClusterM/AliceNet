using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Cards
{
    /// <summary>
    /// Кнопки под списком изображений.
    /// </summary>
    public class CardFooter
    {
        /// <summary>
        /// Текст первой кнопки.
        /// Максимум 64 символа.
        /// Обязательное поле.
        /// </summary>
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        /// <summary>
        /// Дополнительная кнопка для списка изображений.
        /// </summary>
        [JsonPropertyName("button")]
        public CardButton? Button { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта CardFooter.
        /// </summary>
        /// <returns>Строковое представление объекта CardFooter.</returns>
        public override string ToString() => Text;
    }
}
