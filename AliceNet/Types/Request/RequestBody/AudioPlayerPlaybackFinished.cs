using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Событие завершения воспроизведения.
    /// </summary>
    public class AudioPlayerPlaybackFinished : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonIgnore]
        public IRequestBody.RequestTypes RequestType => IRequestBody.RequestTypes.AudioPlayerPlaybackFinished;

        /// <summary>
        /// Возвращает строковое представление объекта AudioPlayerPlaybackFinished.
        /// </summary>
        /// <returns>Строковое представление объекта AudioPlayerPlaybackFinished.</returns>
        public override string ToString() => "AudioPlayerPlaybackFinished";
    }
}
