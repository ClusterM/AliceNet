using System.Text.Json;
using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Слот.
    /// </summary>
    public class Slot
    {
        /// <summary>
        /// Тип.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; }

        /// <summary>
        /// Значение.
        /// </summary>
        [JsonPropertyName("value")]
        public JsonElement? Value { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Slot(string type, JsonElement? value)
        {
            Type = type;
            Value = value;
        }

        /// <summary>
        /// Возвращает строковое представление объекта Slot.
        /// </summary>
        /// <returns>Строковое представление объекта Slot.</returns>
        public override string ToString() => Type;
    }
}
