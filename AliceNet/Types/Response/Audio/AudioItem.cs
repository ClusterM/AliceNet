using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Audio
{
    /// <summary>
    /// Описание трека и аудиопотока.
    /// </summary>
    public class AudioItem
    {
        /// <summary>
        /// Описание аудиопотока.
        /// Обязательное свойство.
        /// </summary>
        [JsonPropertyName("stream")]
        public required AudioStream Stream { get; set; }

        /// <summary>
        /// Метаданные проигрываемого трека.
        /// </summary>
        [JsonPropertyName("metadata")]
        public required AudioMetadata Metadata { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта AudioItem.
        /// </summary>
        /// <returns>Строковое представление объекта AudioItem.</returns>
        public override string ToString() => $"AudioItem: {Stream.Url}";
    }
}
