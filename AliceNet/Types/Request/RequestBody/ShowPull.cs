using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Навык получает запрос с типом Show.Pull, если пользователь произносит команду запуска утренне шоу Алисы. 
    /// </summary>
    public class ShowPull : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonPropertyName("type")]
        public IRequestBody.RequestTypes RequestType => IRequestBody.RequestTypes.ShowPull;

        /// <summary>
        /// Тип шоу. Возможные значения:
        /// * MORNING — утреннее шоу Алисы.
        /// </summary>
        [JsonPropertyName("show_type")]
        public string ShowType { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public ShowPull(string showType)
        {
            ShowType = showType;
        }

        /// <summary>
        /// Возвращает строковое представление объекта ShowPull.
        /// </summary>
        /// <returns>Строковое представление объекта ShowPull.</returns>
        public override string ToString() => $"ShowType: {ShowType}";
    }
}
