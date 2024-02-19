using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Audio
{
    /// <summary>
    /// Метаданные проигрываемого трека.
    /// </summary>
    public class AudioMetadata
    {
        /// <summary>
        /// Описание трека. Например, название композиции.
        /// </summary>
        [JsonPropertyName("title")]
        public required string Title { get; set; }

        /// <summary>
        /// Дополнительное описание трека. Например, имя артиста.
        /// </summary>
        [JsonPropertyName("sub_title")]
        public string? Subtitle { get; set; }

        /// <summary>
        /// Обложка альбома трека.
        /// </summary>
        [JsonPropertyName("art")]
        public Art? Art { get; set; }

        /// <summary>
        /// Фоновое изображение.
        /// </summary>
        [JsonPropertyName("background_image")]
        public BackgroundImage? BackgroundImage { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта AudioPlayer.
        /// </summary>
        /// <returns>Строковое представление объекта AudioPlayer.</returns>
        public override string ToString() => $"AudioMetadata: {$"{Title} {Subtitle}".Trim()}";
    }
}
