using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Атрибуты пользователя Яндекса, который взаимодействует с навыком. Если пользователь не авторизован в приложении, 
    /// свойства user в запросе не будет.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя Яндекса, единый для всех приложений и устройств.
        /// Этот идентификатор уникален для пары «пользователь — навык»: в разных навыках значение свойства user_id 
        /// для одного и того же пользователя будет различаться.
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; }

        /// <summary>
        /// Токен для OAuth-авторизации, который также передается в заголовке Authorization для навыков с настроенной связкой аккаунтов.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public User(string userId, string accessToken)
        {
            UserId = userId;
            AccessToken = accessToken;
        }

        /// <summary>
        /// Возвращает строковое представление объекта User.
        /// </summary>
        /// <returns>Строковое представление объекта User.</returns>
        public override string ToString() => $"User: {UserId}";
    }
}
