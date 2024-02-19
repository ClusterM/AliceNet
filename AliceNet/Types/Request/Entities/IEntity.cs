using System.Text.Json;
using System.Text.Json.Serialization;
using static wtf.cluster.AliceNet.Types.Request.RequestBody.IRequestBody;

namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Именованная сущность.
    /// </summary>
    [JsonConverter(typeof(EntityConverter))]
    public interface IEntity
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonConverter(typeof(RequestTypeConverter))]
        public enum EntityTypes
        {
            /// <summary>
            /// Дата и время, абсолютные или относительные.
            /// </summary>
            DateTime,
            /// <summary>
            /// Фамилия, имя и отчество.
            /// </summary>
            FIO,
            /// <summary>
            /// Местоположение (адрес или аэропорт).
            /// </summary>
            GEO,
            /// <summary>
            /// Число, целое или с плавающей точкой.
            /// </summary>
            Number
        }

        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonPropertyName("type")]
        public EntityTypes EntityType { get; }

        /// <summary>
        /// Начало и конец именованной сущности.
        /// </summary>        
        [JsonPropertyName("tokens")]
        public Tokens Tokens { get; }

        /// <summary>
        /// JSON converter for serialization and deserialization.
        /// </summary>
        public class EntityConverter : JsonConverter<IEntity>
        {
            /// <summary>
            /// IEntity objects deserializer.
            /// </summary>
            public override IEntity? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                var root = document.RootElement;
                var t = root.GetProperty("type").GetString();
                switch (t)
                {
                    case "YANDEX.DATETIME":
                        return root.Deserialize<DateTimeEntity>(options);
                    case "YANDEX.FIO":
                        return root.Deserialize<FIOEntity>(options);
                    case "YANDEX.GEO":
                        return root.Deserialize<GEOEntity>(options);
                    case "YANDEX.NUMBER":
                        return root.Deserialize<NumberEntity>(options);
                    default:
                        throw new JsonException($"Can't deserialize {typeToConvert} object, unknown type: {t}");
                }
            }

            /// <summary>
            /// IEntity objects serializer.
            /// </summary>
            public override void Write(Utf8JsonWriter writer, IEntity value, JsonSerializerOptions options)
            {
                switch (value)
                {
                    case DateTimeEntity dateTimeEntity:
                        JsonSerializer.Serialize(writer, dateTimeEntity, options);
                        break;
                    case FIOEntity fioEntity:
                        JsonSerializer.Serialize(writer, fioEntity, options);
                        break;
                    case GEOEntity geoEntity:
                        JsonSerializer.Serialize(writer, geoEntity, options);
                        break;
                    case NumberEntity numberEntity:
                        JsonSerializer.Serialize(writer, numberEntity, options);
                        break;
                    default:
                        throw new JsonException($"Can't serialize {value.GetType()} object, unknown type");
                }
            }
        }

        /// <summary>
        /// JSON converter for serialization and deserialization.
        /// </summary>
        public class RequestTypeConverter : JsonConverter<EntityTypes>
        {
            /// <summary>
            /// RequestTypes objects deserializer.
            /// </summary>
            public override EntityTypes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                JsonElement root = document.RootElement;
                var t = root.GetString();
                if (t == null)
                    throw new JsonException("Can't deserialize EntityTypes object, type is null");
                switch (t)
                {
                    case "YANDEX.DATETIME":
                        return EntityTypes.DateTime;
                    case "YANDEX.FIO":
                        return EntityTypes.FIO;
                    case "YANDEX.GEO":
                        return EntityTypes.GEO;
                    case "YANDEX.NUMBER":
                        return EntityTypes.Number;
                    default:
                        throw new JsonException($"Can't deserialize {typeToConvert} object, unknown type: {t}");
                }
            }

            /// <summary>
            /// RequestTypes objects serializer.
            /// </summary>
            public override void Write(Utf8JsonWriter writer, EntityTypes value, JsonSerializerOptions options)
            {
                switch (value)
                {
                    case EntityTypes.DateTime:
                        writer.WriteStringValue("YANDEX.DATETIME");
                        break;
                    case EntityTypes.FIO:
                        writer.WriteStringValue("YANDEX.FIO");
                        break;
                    case EntityTypes.GEO:
                        writer.WriteStringValue("YANDEX.GEO");
                        break;
                    case EntityTypes.Number:
                        writer.WriteStringValue("YANDEX.NUMBER");
                        break;
                    default:
                        throw new JsonException($"Can't serialize {value.GetType()} object, unknown type");
                }
            }
        }
    }
}
