using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Audio
{
    /// <summary>
    /// Описание аудиопотока.
    /// </summary>
    public class AudioStream
    {
        /// <summary>
        /// URL аудиопотока.
        /// Обязательное свойство.
        /// </summary>
        [JsonPropertyName("url")]
        public required string Url { get; set; }

        /// <summary>
        /// Временная метка, с которой необходимо проигрывать трек. Чтобы проиграть трек с начала, нужно передать значение 0.
        /// Обязательное свойство.
        /// </summary>
        [JsonPropertyName("offset_ms")]
        public required int? OffsetInSeconds { get; set; }

        /// <summary>
        /// Идентификатор потока. Может быть использован для кеширования изображений или для постановки трека в очередь на стороне навыка.
        /// Обязательное свойство.
        /// </summary>
        [JsonPropertyName("token")]
        public required string? Token { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта AudioStream.
        /// </summary>
        /// <returns>Строковое представление объекта AudioStream.</returns>
        public override string ToString() => $"AudioStream: {Url}";
    }
}
