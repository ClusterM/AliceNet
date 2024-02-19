using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Ошибка.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Детальная информация об ошибке.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; }

        /// <summary>
        /// Код ошибки.
        /// </summary>
        [JsonPropertyName("type")]
        public string ErrorType { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Error(string message, string type)
        {
            Message = message;
            ErrorType = type;
        }

        /// <summary>
        /// Возвращает строковое представление объекта Error.
        /// </summary>
        /// <returns>Строковое представление объекта Error.</returns>
        public override string ToString() => $"{ErrorType}: {Message}";
    }
}
