using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Cards
{
    /// <summary>
    /// Описание карточки — сообщения с поддержкой изображений. 
    /// Если приложению удается отобразить карточку для пользователя, свойство AliceResponse.Text не используется.
    /// </summary>
    public class ItemsListCard : ICard
    {
        /// <summary>
        /// Тип карточки. 
        /// </summary>
        [JsonPropertyName("type")]
        public ICard.CardTypes CardType { get => ICard.CardTypes.ItemsList; }

        /// <summary>
        /// Заголовок списка изображений.
        /// </summary>
        [JsonPropertyName("header")]
        public CardHeader? Header { get; set; }

        /// <summary>
        /// Кнопки под списком изображений.
        /// </summary>
        [JsonPropertyName("footer")]
        public CardFooter? Footer { get; set; }

        /// <summary>
        /// Набор от 1 до 10 изображений.
        /// </summary>
        [JsonPropertyName("items")]
        public required IEnumerable<ImageCardItem> Items { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта ItemsListCard.
        /// </summary>
        /// <returns>Строковое представление объекта ItemsListCard.</returns>
        public override string ToString() => Header?.ToString() ?? $"{Items.Count()} items";
    }
}
