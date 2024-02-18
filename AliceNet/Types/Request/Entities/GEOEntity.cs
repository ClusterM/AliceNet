using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Местоположение (адрес или аэропорт).
    /// </summary>
    public class GEOEntity : IEntity
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonIgnore]
        public IEntity.EntityTypes EntityType => IEntity.EntityTypes.GEO;

        /// <summary>
        /// Местоположение (адрес или аэропорт).
        /// </summary>
        [JsonPropertyName("value")]
        public GEOEntityValue Value { get; }

        /// <summary>
        /// Обозначение начала и конца именованной сущности в массиве слов. Нумерация слов в массиве начинается с 0.
        /// </summary>
        [JsonPropertyName("tokens")]
        public Tokens Tokens { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public GEOEntity(GEOEntityValue value, Tokens tokens)
        {
            Value = value;
            Tokens = tokens;
        }
    }
}
