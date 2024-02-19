using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Дата и время. Значения могут быть относительными или абсолютными.
    /// </summary>
    public class DateTimeEntity : IEntity
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonIgnore]
        public IEntity.EntityTypes EntityType => IEntity.EntityTypes.DateTime;

        /// <summary>
        /// Дата и время. Значения могут быть относительными или абсолютными.
        /// </summary>
        [JsonPropertyName("value")]
        public DateTimeEntityValue Value { get; }

        /// <summary>
        /// Обозначение начала и конца именованной сущности в массиве слов. Нумерация слов в массиве начинается с 0.
        /// </summary>
        [JsonPropertyName("tokens")]
        public Tokens Tokens { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public DateTimeEntity(DateTimeEntityValue value, Tokens tokens)
        {
            Value = value;
            Tokens = tokens;
        }

        /// <summary>
        /// Возвращает строковое представление объекта DateTimeEntity.
        /// </summary>
        /// <returns>Строковое представление объекта DateTimeEntity.</returns>
        public override string ToString() => Value.ToString();
    }
}
