using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Местоположение (адрес или аэропорт).
    /// </summary>
    public class GEOEntityValue : IEntityValue
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonIgnore]
        public IEntity.EntityTypes EntityType { get => IEntity.EntityTypes.GEO; }

        /// <summary>
        /// Страна.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; }

        /// <summary>
        /// Город.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; }

        /// <summary>
        /// Улица.
        /// </summary>
        [JsonPropertyName("street")]
        public string? Street { get; }

        /// <summary>
        /// Дом.
        /// </summary>
        [JsonPropertyName("house_number")]
        public string? HouseNumber { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        public GEOEntityValue(string? country, string? city, string? street, string? houseNumber)
        {
            Country = country;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        /// <summary>
        /// Возвращает строковое представление объекта GEOEntityValue.
        /// </summary>
        /// <returns>Строковое представление объекта GEOEntityValue.</returns>
        public override string ToString() => String.Join(", ", new[] { Country, City, Street, HouseNumber }.Where(s => !String.IsNullOrWhiteSpace(s)));
    }
}