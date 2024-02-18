using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Данные о приложении, с помощью которого пользователь взаимодействует с навыком.
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Идентификатор экземпляра приложения, в котором пользователь общается с Алисой, максимум 64 символа.
        /// Даже если пользователь вошел в один и тот же аккаунт в приложение Яндекс для Android и iOS, Яндекс Диалоги 
        /// присвоят отдельный application_id каждому из этих приложений.
        /// Этот идентификатор уникален для пары «приложение — навык»: в разных навыках значение свойства application_id 
        /// для одного и того же пользователя будет различаться.
        /// </summary>
        [JsonPropertyName("application_id")]
        public string ApplicationId { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Application(string applicationId)
        {
            ApplicationId = applicationId;
        }

        /// <summary>
        /// Возвращает строковое представление объекта Markup.
        /// </summary>
        /// <returns>Строковое представление объекта Markup.</returns>
        public override string ToString() => $"ApplicationId: {ApplicationId}";
    }
}
