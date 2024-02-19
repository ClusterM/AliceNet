using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Фамилия, имя и отчество.
    /// </summary>
    public class FIOEntityValue : IEntityValue
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonIgnore]
        public IEntity.EntityTypes EntityType { get => IEntity.EntityTypes.FIO; }

        /// <summary>
        /// Имя.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string? FirstName { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [JsonPropertyName("patronymic_name")]
        public string? PatronymicName { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        public FIOEntityValue(string? firstName, string? lastName, string? patronymicName)
        {
            FirstName = firstName;
            LastName = lastName;
            PatronymicName = patronymicName;
        }

        /// <summary>
        /// Возвращает строковое представление объекта FIOEntityValue.
        /// </summary>
        /// <returns>Строковое представление объекта FIOEntityValue.</returns>
        public override string ToString() => String.Join(", ", new[] { FirstName, LastName, PatronymicName }.Where(s => !String.IsNullOrWhiteSpace(s)));
    }
}