using System.Text.Json.Serialization;
using wtf.cluster.AliceNet.Types.Response;

namespace wtf.cluster.AliceNet.Types
{
    /// <summary>
    /// Ответ, который навык возвращает Алисе.
    /// </summary>
    public class AliceResponse
    {
        /// <summary>
        /// Тело ответа.
        /// </summary>
        [JsonPropertyName("response")]
        public required ResponseBody Response { get; set; }

        /// <summary>
        /// Объект, содержащий состояние навыка для хранения в контексте сессии.
        /// </summary>
        [JsonPropertyName("session_state")]
        public Dictionary<string, object>? SessionState { get; set; }

        /// <summary>
        /// Объект, содержащий состояние навыка для хранения в контексте авторизованного пользователя.
        /// </summary>
        [JsonPropertyName("user_state_update")]
        public Dictionary<string, object>? UserStateUpdate { get; set; }

        /// <summary>
        /// Объект, содержащий состояние навыка для хранения в контексте экземпляра приложения пользователя.
        /// </summary>
        [JsonPropertyName("application_state")]
        public Dictionary<string, object>? ApplicationState { get; set; }

        /// <summary>
        /// Объект с данными для аналитики.
        /// Доступен навыкам с подключенным параметром Настройки AppMetrica. Подробнее: https://yandex.ru/dev/dialogs/alice/doc/appmetrica.html
        /// </summary>
        [JsonPropertyName("analytics")]
        public Analytics? Analytics { get; set; }

        /// <summary>
        /// Версия протокола. Текущая версия — 1.0.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; } = "1.0";

        /// <summary>
        /// Возвращает строковое представление объекта AliceResponse.
        /// </summary>
        /// <returns>Строковое представление объекта AliceResponse.</returns>
        public override string ToString() => $"{Response}";
    }
}
