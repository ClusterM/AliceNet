using System.Text.Json;
using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Cards
{
    /// <summary>
    /// Описание карточки — сообщения с поддержкой изображений.
    /// Если приложению удается отобразить карточку для пользователя, свойство response.text не используется.
    /// Возможные значения:
    /// * BigImage — одно изображение.
    /// * ItemsList — список из нескольких изображений (от 1 до 5).
    /// * ImageGallery — галерея из нескольких изображений(от 1 до 7).
    /// </summary>
    [JsonConverter(typeof(ICard.JsonSchemaConverter))]
    public interface ICard
    {
        /// <summary>
        /// Тип карточки.
        /// </summary>
        public enum CardTypes
        {
            /// <summary>
            /// Одно изображение.
            /// </summary>
            BigImage,
            /// <summary>
            /// Список из нескольких изображений (от 1 до 5).
            /// </summary>
            ItemsList,
            /// <summary>
            /// Галерея из нескольких изображений(от 1 до 7).
            /// </summary>
            ImageGallery
        }

        /// <summary>
        /// Тип карточки.
        /// </summary>
        public CardTypes CardType { get; }

        /// <summary>
        /// JSON converter for serialization and deserialization.
        /// </summary>
        public class JsonSchemaConverter : JsonConverter<ICard>
        {
            /// <summary>
            /// ICard objects deserializer. Unused.
            /// </summary>
            public override ICard? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// ICard objects serializer.
            /// </summary>
            public override void Write(Utf8JsonWriter writer, ICard value, JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, value, value.GetType(), options);
            }
        }
    }
}
