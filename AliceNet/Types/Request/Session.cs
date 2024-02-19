using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Данные о сессии. Сессия — это период относительно непрерывного взаимодействия пользователя с навыком.
    /// Сессия завершается, когда:
    /// * пользователь запрашивает выход из навыка;
    /// * навык явно завершает работу("end_session": true);
    /// * от пользователя долго не поступает команд (тайм-аут зависит от поверхности, минимум несколько минут).
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Уникальный идентификатор сессии, максимум 64 символа.
        /// </summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; }

        /// <summary>
        /// Идентификатор сообщения в рамках сессии, максимум 8 символов.
        /// Инкрементируется с каждым следующим запросом.
        /// </summary>
        [JsonPropertyName("message_id")]
        public int MessageId { get; }

        /// <summary>
        /// Идентификатор вызываемого навыка, присвоенный при создании.
        /// </summary>
        [JsonPropertyName("skill_id")]
        public string SkillId { get; }

        /// <summary>
        /// Атрибуты пользователя Яндекса, который взаимодействует с навыком. Если пользователь не авторизован в приложении, 
        /// свойства user в запросе не будет.
        /// </summary>
        [JsonPropertyName("user")]
        public User? User { get; }

        /// <summary>
        /// Данные о приложении, с помощью которого пользователь взаимодействует с навыком.
        /// </summary>
        [JsonPropertyName("application")]
        public Application Application { get; }

        /// <summary>
        /// Признак новой сессии.
        /// </summary>
        [JsonPropertyName("new")]
        public bool New { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Session(string sessionId, int messageId, string skillId, User? user, Application application, bool @new)
        {
            SessionId = sessionId;
            MessageId = messageId;
            SkillId = skillId;
            User = user;
            Application = application;
            New = @new;
        }
    }
}
