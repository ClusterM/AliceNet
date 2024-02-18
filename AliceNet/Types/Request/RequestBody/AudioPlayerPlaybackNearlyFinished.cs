using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Cобытие возникает за некоторое время до конца проигрывания текущего трека.
    /// </summary>
    public class AudioPlayerPlaybackNearlyFinished : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonIgnore]
        public IRequestBody.RequestTypes RequestType { get => IRequestBody.RequestTypes.AudioPlayerPlaybackNearlyFinished; }

        /// <summary>
        /// Возвращает строковое представление объекта AudioPlayerPlaybackNearlyFinished.
        /// </summary>
        /// <returns>Строковое представление объекта AudioPlayerPlaybackNearlyFinished.</returns>
        public override string ToString() => "AudioPlayerPlaybackNearlyFinished";
    }
}
