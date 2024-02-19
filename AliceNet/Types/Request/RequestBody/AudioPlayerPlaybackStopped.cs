using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Событие остановки вопроизведения. Срабатывает при одном из двух условий:
    /// * Навык отправил команду Stop, и проигрывание трека остановилось.
    /// * Алиса приостановила проигрывание для обработки голосового запроса.
    /// </summary>
    public class AudioPlayerPlaybackStopped : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonPropertyName("type")]
        public IRequestBody.RequestTypes RequestType { get => IRequestBody.RequestTypes.AudioPlayerPlaybackStopped; }

        /// <summary>
        /// Возвращает строковое представление объекта AudioPlayerPlaybackStopped.
        /// </summary>
        /// <returns>Строковое представление объекта AudioPlayerPlaybackStopped.</returns>
        public override string ToString() => "AudioPlayerPlaybackStopped";
    }
}
