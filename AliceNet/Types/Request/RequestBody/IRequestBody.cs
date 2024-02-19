using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Интерфейс для тела запроса.
    /// </summary>
    [JsonConverter(typeof(RequestBodyConverter))]
    public interface IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonConverter(typeof(RequestTypeConverter))]
        public enum RequestTypes
        {
            /// <summary>
            /// Голосовой ввод.
            /// </summary>
            SimpleUtterance,
            /// <summary>
            /// Нажатие кнопки.
            /// </summary>
            ButtonPressed,
            /// <summary>
            /// Cобытие начала воспроизведения аудиоплеером на умных колонках.
            /// </summary>
            AudioPlayerPlaybackStarted,
            /// <summary>
            /// Событие завершения воспроизведения.
            /// </summary>
            AudioPlayerPlaybackFinished,
            /// <summary>
            /// Событие о скором завершении воспроизведения текущего трека.
            /// </summary>
            AudioPlayerPlaybackNearlyFinished,
            /// <summary>
            /// Остановка воспроизведения.
            /// </summary>
            AudioPlayerPlaybackStopped,
            /// <summary>
            /// Ошибка воспроизведения.
            /// </summary>
            AudioPlayerPlaybackFailed,
            /// <summary>
            /// Запрос на подтверждение оплаты в навыке.
            /// </summary>
            PurchaseConfirmation,
            /// <summary>
            /// Запрос на чтение данных для шоу.
            /// </summary>
            ShowPull
        }

        /// <summary>
        /// Тип запроса.
        /// </summary>
        public RequestTypes RequestType { get; }

        /// <summary>
        /// JSON converter for serialization and deserialization.
        /// </summary>
        public class RequestBodyConverter : JsonConverter<IRequestBody>
        {
            /// <summary>
            /// IRequestBody objects deserializer.
            /// </summary>
            public override IRequestBody? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                JsonElement root = document.RootElement;
                var t = root.GetProperty("type").GetString();
                switch (t)
                {
                    case "SimpleUtterance":
                        return root.Deserialize<SimpleUtterance>(options);
                    case "ButtonPressed":
                        return root.Deserialize<ButtonPressed>(options);
                    case "AudioPlayerPlaybackStarted":
                        return root.Deserialize<AudioPlayerPlaybackStarted>(options);
                    case "AudioPlayerPlaybackFinished":
                        return root.Deserialize<AudioPlayerPlaybackFinished>(options);
                    case "AudioPlayerPlaybackNearlyFinished":
                        return root.Deserialize<AudioPlayerPlaybackNearlyFinished>(options);
                    case "AudioPlayerPlaybackStopped":
                        return root.Deserialize<AudioPlayerPlaybackStopped>(options);
                    case "AudioPlayerPlaybackFailed":
                        return root.Deserialize<AudioPlayerPlaybackFailed>(options);
                    case "PurchaseConfirmation":
                        return root.Deserialize<PurchaseConfirmation>(options);
                    case "ShowPull":
                        return root.Deserialize<ShowPull>(options);
                    default:
                        throw new JsonException($"Can't deserialize {typeToConvert} object, unknown type: {t}");
                }
            }

            /// <summary>
            /// IRequestBody objects serializer.
            /// </summary>
            public override void Write(Utf8JsonWriter writer, IRequestBody value, JsonSerializerOptions options)
            {
                switch (value)
                {
                    case SimpleUtterance simpleUtterance:
                        JsonSerializer.Serialize(writer, simpleUtterance, options);
                        break;
                    case ButtonPressed buttonPressed:
                        JsonSerializer.Serialize(writer, buttonPressed, options);
                        break;
                    case AudioPlayerPlaybackStarted audioPlayerPlaybackStarted:
                        JsonSerializer.Serialize(writer, audioPlayerPlaybackStarted, options);
                        break;
                    case AudioPlayerPlaybackFinished audioPlayerPlaybackFinished:
                        JsonSerializer.Serialize(writer, audioPlayerPlaybackFinished, options);
                        break;
                    case AudioPlayerPlaybackNearlyFinished audioPlayerPlaybackNearlyFinished:
                        JsonSerializer.Serialize(writer, audioPlayerPlaybackNearlyFinished, options);
                        break;
                    case AudioPlayerPlaybackStopped audioPlayerPlaybackStopped:
                        JsonSerializer.Serialize(writer, audioPlayerPlaybackStopped, options);
                        break;
                    case AudioPlayerPlaybackFailed audioPlayerPlaybackFailed:
                        JsonSerializer.Serialize(writer, audioPlayerPlaybackFailed, options);
                        break;
                    case PurchaseConfirmation purchaseConfirmation:
                        JsonSerializer.Serialize(writer, purchaseConfirmation, options);
                        break;
                    case ShowPull showPull:
                        JsonSerializer.Serialize(writer, showPull, options);
                        break;
                    default:
                        throw new JsonException($"Can't serialize {value.GetType()} object, unknown type");
                }
            }
        }

        /// <summary>
        /// JSON converter for serialization and deserialization.
        /// </summary>
        public class RequestTypeConverter : JsonConverter<RequestTypes>
        {
            /// <summary>
            /// RequestTypes objects deserializer.
            /// </summary>
            public override RequestTypes Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using JsonDocument document = JsonDocument.ParseValue(ref reader);
                JsonElement root = document.RootElement;
                var t = root.GetString();
                if (t == null)
                    throw new JsonException("Can't deserialize RequestTypes object, type is null");
                if (t == "Show.Pull")
                    return RequestTypes.ShowPull;
                else
                    return Enum.Parse<RequestTypes>(t);
            }

            /// <summary>
            /// RequestTypes objects serializer.
            /// </summary>
            public override void Write(Utf8JsonWriter writer, RequestTypes value, JsonSerializerOptions options)
            {
                if (value == RequestTypes.ShowPull)
                    writer.WriteStringValue("Show.Pull");
                else
                    writer.WriteStringValue(value.ToString());
            }
        }
    }
}
