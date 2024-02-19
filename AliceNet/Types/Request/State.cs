using System.Text.Json;
using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Данные о сохраненном состоянии.
    /// </summary>
    public class State
    {
        /// <summary>
        /// Состояние навыка в контексте сессии.
        /// </summary>
        [JsonPropertyName("session")]
        public JsonElement? Session { get; }

        /// <summary>
        /// Состояние навыка в контексте авторизованного пользователя.
        /// </summary>
        [JsonPropertyName("user")]
        public JsonElement? User { get; }

        /// <summary>
        /// Состояние навыка в контексте экземпляра приложения пользователя.
        /// </summary>
        [JsonPropertyName("application")]
        public JsonElement Application { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public State(JsonElement? session, JsonElement? user, JsonElement application)
        {
            Session = session;
            User = user;
            Application = application;
        }
    }
}
