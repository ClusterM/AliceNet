using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Число, целое или с плавающей точкой.
    /// </summary>
    public class NumberEntity : IEntity
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonIgnore]
        public IEntity.EntityTypes EntityType => IEntity.EntityTypes.Number;

        /// <summary>
        /// Число, целое или с плавающей точкой.
        /// </summary>
        [JsonPropertyName("value")]
        public double Value { get; }

        /// <summary>
        /// Обозначение начала и конца именованной сущности в массиве слов. Нумерация слов в массиве начинается с 0.
        /// </summary>
        [JsonPropertyName("tokens")]
        public Tokens Tokens { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public NumberEntity(double value, Tokens tokens)
        {
            Value = value;
            Tokens = tokens;
        }

        /// <summary>
        /// Возвращает строковое представление объекта NumberEntity.
        /// </summary>
        /// <returns>Строковое представление объекта NumberEntity.</returns>
        public override string ToString() => $"NumberEntity: {Value}";
    }
}
