using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Audio
{
    /// <summary>
    /// Обложка альбома трека.
    /// </summary>
    public class Art
    {
        /// <summary>
        /// URL обложки альбома.
        /// </summary>
        [JsonPropertyName("url")]
        public required string Url { get; set; }

        /// <summary>
        /// Main JSON constructor for deserialization.
        /// </summary>
        public Art(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Возвращает строковое представление объекта AudioStream.
        /// </summary>
        /// <returns>Строковое представление объекта AudioStream.</returns>
        public override string ToString() => $"Art: {Url}";
    }
}
