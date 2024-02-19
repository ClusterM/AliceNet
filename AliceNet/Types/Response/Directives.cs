using System.Text.Json.Serialization;
using wtf.cluster.AliceNet.Types.Response.Audio;

namespace wtf.cluster.AliceNet.Types.Response
{
    /// <summary>
    /// Директивы.
    /// </summary>
    public class Directives
    {
        /// <summary>
        /// Запуск аудиоплеера на умных колонках;
        /// </summary>
        [JsonPropertyName("audio_player")]
        public AudioPlayer? AudioPlayer { get; set; }

        /// <summary>
        /// Запуск процесса авторизации в навыке.
        /// </summary>
        [JsonPropertyName("start_account_linking")]
        public StartAccountLinking? StartAccountLinking { get; set; }
    }
}
