using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Информация о намерениях пользователя.
    /// </summary>
    public class Intent
    {
        /// <summary>
        /// Список слотов.
        /// </summary>
        [JsonPropertyName("slots")]
        public Dictionary<string, Slot> Slots { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Intent(Dictionary<string, Slot> slots)
        {
            Slots = slots;
        }
    }
}
