using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Audio
{
    /// <summary>
    /// Директива управления плеером.
    /// </summary>
    public class AudioPlayer
    {
        /// <summary>
        /// Команда плееру.
        /// </summary>
        public enum Actions
        {
            /// <summary>
            /// Проигрывание трека, начинается сразу после отправки директивы. Проигрывание текущего трека приостанавливается.
            /// </summary>
            Play,
            /// <summary>
            /// Остановка трека.
            /// </summary>
            Stop
        }

        /// <summary>
        /// Команда директиве.
        /// Play — проигрывание трека, начинается сразу после отправки директивы. Проигрывание текущего трека приостанавливается.
        /// Stop — остановка трека.
        /// Обязательное свойство.
        /// </summary>
        [JsonPropertyName("action")]
        public Actions Action { get; set; }

        /// <summary>
        /// Описание трека и аудиопотока.
        /// </summary>
        [JsonPropertyName("item")]
        public AudioItem? Item { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта AudioPlayer.
        /// </summary>
        /// <returns>Строковое представление объекта AudioPlayer.</returns>
        public override string ToString() => $"AudioPlayer: {Action}";
    }
}
