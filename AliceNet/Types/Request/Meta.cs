using System.Text.Json;
using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Информация об устройстве, с помощью которого пользователь разговаривает с Алисой.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Язык в POSIX-формате, максимум 64 символа.
        /// </summary>
        [JsonPropertyName("locale")]
        public string Locale { get; }

        /// <summary>
        /// Название часового пояса, включая алиасы, максимум 64 символа.
        /// </summary>
        [JsonPropertyName("timezone")]
        public string Timezone { get; }

        /// <summary>
        /// Идентификатор устройства и приложения, в котором идет разговор, максимум 1024 символа.
        /// Не рекомендуется к использованию. Интерфейсы, доступные на клиентском устройстве, перечислены в свойстве Interfaces.
        /// </summary>
        [JsonPropertyName("client_id")]
        public string ClientId { get; }

        /// <summary>
        /// Интерфейсы, доступные на устройстве пользователя.
        /// На практике могут быть доступны следующие интерфейсы, которых нет в документации.
        /// </summary>
        [JsonPropertyName("interfaces")]
        public Dictionary<string, JsonElement?> Interfaces { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Meta(string locale, string timezone, string clientId, Dictionary<string, JsonElement?> interfaces)
        {
            Locale = locale;
            Timezone = timezone;
            ClientId = clientId;
            Interfaces = interfaces;
        }

        /// <summary>
        /// Возвращает строковое представление объекта Meta.
        /// </summary>
        /// <returns>Строковое представление объекта Meta.</returns>
        public override string ToString() => $"ClientId: {ClientId}";
    }
}
