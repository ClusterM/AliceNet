using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Cards
{
    /// <summary>
    /// Галерея из нескольких изображений(от 1 до 7).
    /// </summary>
    public class ImageGalleryCard : ICard
    {
        /// <summary>
        /// Тип карточки.
        /// </summary>
        [JsonPropertyName("type")]
        public ICard.CardTypes CardType { get => ICard.CardTypes.ImageGallery; }

        /// <summary>
        /// Набор от 1 до 10 изображений.
        /// </summary>
        [JsonPropertyName("items")]
        public required IEnumerable<ImageCardItem> Items { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта ImageGalleryCard.
        /// </summary>
        /// <returns>Строковое представление объекта ImageGalleryCard.</returns>
        public override string ToString() => $"ImageGalleryCard: {Items.Count()} items";
    }
}
