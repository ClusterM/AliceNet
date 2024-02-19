using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Фамилия, имя и отчество.
    /// </summary>
    public class FIOEntity : IEntity
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonIgnore]
        public IEntity.EntityTypes EntityType => IEntity.EntityTypes.FIO;

        /// <summary>
        /// Фамилия, имя и отчество.
        /// </summary>
        [JsonPropertyName("value")]
        public FIOEntityValue Value { get; }

        /// <summary>
        /// Обозначение начала и конца именованной сущности в массиве слов. Нумерация слов в массиве начинается с 0.
        /// </summary>
        [JsonPropertyName("tokens")]
        public Tokens Tokens { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public FIOEntity(FIOEntityValue value, Tokens tokens)
        {
            Value = value;
            Tokens = tokens;
        }

        /// <summary>
        /// Возвращает строковое представление объекта FIOEntity.
        /// </summary>
        /// <returns>Строковое представление объекта FIOEntity.</returns>
        public override string ToString() => Value.ToString();
    }
}
