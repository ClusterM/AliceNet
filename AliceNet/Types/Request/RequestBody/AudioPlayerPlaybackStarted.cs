using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Событие начала воспроизведения трека на умных колонках.
    /// </summary>
    public class AudioPlayerPlaybackStarted : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonPropertyName("type")]
        public IRequestBody.RequestTypes RequestType { get => IRequestBody.RequestTypes.AudioPlayerPlaybackStarted; }

        /// <summary>
        /// Возвращает строковое представление объекта AudioPlayerPlaybackStarted.
        /// </summary>
        /// <returns>Строковое представление объекта AudioPlayerPlaybackStarted.</returns>
        public override string ToString() => "AudioPlayerPlaybackStarted";
    }
}
