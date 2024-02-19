using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Событие ошибки воспроизведения.
    /// </summary>
    public class AudioPlayerPlaybackFailed : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonPropertyName("type")]
        public IRequestBody.RequestTypes RequestType { get => IRequestBody.RequestTypes.AudioPlayerPlaybackFailed; }

        /// <summary>
        /// Описание ошибки.
        /// </summary>
        [JsonPropertyName("error")]
        public Error Error { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public AudioPlayerPlaybackFailed(Error error)
        {
            Error = error;
        }

        /// <summary>
        /// Возвращает строковое представление объекта AudioPlayerPlaybackFailed.
        /// </summary>
        /// <returns>Строковое представление объекта AudioPlayerPlaybackFailed.</returns>
        public override string ToString() => $"AudioPlayerPlaybackFailed: {Error}";
    }
}
