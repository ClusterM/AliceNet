using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Cards
{
    /// <summary>
    /// Описание карточки — сообщения с поддержкой изображений. 
    /// Если приложению удается отобразить карточку для пользователя, свойство AliceResponse.Text не используется.
    /// </summary>
    public class BigImageCard : ICard
    {
        /// <summary>
        /// Тип карточки. 
        /// </summary>
        [JsonPropertyName("type")]
        public ICard.CardTypes CardType { get => ICard.CardTypes.BigImage; }

        /// <summary>
        /// Идентификатор изображения, который возвращается в ответ на запрос загрузки.
        /// </summary>
        [JsonPropertyName("image_id")]
        public string? ImageId { get; set; }

        /// <summary>
        /// Заголовок для изображения.
        /// Максимум 128 символов.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Описание изображения.
        /// Максимум 1024 символа.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Свойства кликабельного изображения.
        /// </summary>
        [JsonPropertyName("button")]
        public CardButton? Button { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта BigImageCard.
        /// </summary>
        /// <returns>Строковое представление объекта BigImageCard.</returns>
        public override string ToString() => $"BigImageCard: {Title}";
    }
}
