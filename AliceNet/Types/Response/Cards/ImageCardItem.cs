using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Cards
{
    /// <summary>
    /// Изображение.
    /// </summary>
    public class ImageCardItem
    {
        /// <summary>
        /// Идентификатор изображения, который возвращается в ответ на запрос загрузки.
        /// </summary>
        [JsonPropertyName("image_id")]
        public required string ImageId { get; set; }

        /// <summary>
        /// Заголовок для изображения.
        /// Максимум 128 символов.
        /// </summary>
        [JsonPropertyName("title")]
        public required string Title { get; set; }

        /// <summary>
        /// Описание изображения
        /// Максимум 256 символов.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Свойства кликабельного изображения.
        /// </summary>
        [JsonPropertyName("button")]
        public CardButton? Button { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта ImageCardItem.
        /// </summary>
        /// <returns>Строковое представление объекта ImageCardItem.</returns>
        public override string ToString() => Title;
    }
}
