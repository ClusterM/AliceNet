using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.Entities
{
    /// <summary>
    /// Дата и время. Значения могут быть относительными или абсолютными.
    /// </summary>
    public class DateTimeEntityValue : IEntityValue
    {
        /// <summary>
        /// Тип именованной сущности.
        /// </summary>
        [JsonIgnore]
        public IEntity.EntityTypes EntityType { get => IEntity.EntityTypes.DateTime; }

        /// <summary>
        /// Точный год.
        /// </summary>
        [JsonPropertyName("year")]
        public int? Year { get; }

        /// <summary>
        /// Признак того, что в поле year указано относительное количество лет.
        /// </summary>
        [JsonPropertyName("year_is_relative")]
        public bool? YearIsRelative { get; }

        /// <summary>
        /// Месяц.
        /// </summary>
        [JsonPropertyName("month")]
        public int? Month { get; }

        /// <summary>
        /// Признак того, что в поле month указано относительное количество месяцев.
        /// </summary>
        [JsonPropertyName("month_is_relative")]
        public bool? MonthIsRelative { get; }

        /// <summary>
        /// День.
        /// </summary>
        [JsonPropertyName("day")]
        public int? Day { get; }

        /// <summary>
        /// Признак того, что в поле day указано относительное количество дней.
        /// </summary>
        [JsonPropertyName("day_is_relative")]
        public bool? DayIsRelative { get; }

        /// <summary>
        /// Час.
        /// </summary>
        [JsonPropertyName("hour")]
        public int? Hour { get; }

        /// <summary>
        /// Признак того, что в поле hour указано относительное количество часов.
        /// </summary>
        [JsonPropertyName("hour_is_relative")]
        public bool? HourIsRelative { get; }

        /// <summary>
        /// Минута.
        /// </summary>
        [JsonPropertyName("minute")]
        public int? Minute { get; }

        /// <summary>
        /// Признак того, что в поле minute указано относительное количество минут.
        /// </summary>
        [JsonPropertyName("minute_is_relative")]
        public bool? MinuteIsRelative { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public DateTimeEntityValue(int? year, bool? yearIsRelative, int? month, bool? monthIsRelative,
            int? day, bool? dayIsRelative, int? hour, bool? hourIsRelative, int? minute, bool? minuteIsRelative)
        {
            Year = year;
            YearIsRelative = yearIsRelative;
            Month = month;
            MonthIsRelative = monthIsRelative;
            Day = day;
            DayIsRelative = dayIsRelative;
            Hour = hour;
            HourIsRelative = hourIsRelative;
            Minute = minute;
            MinuteIsRelative = minuteIsRelative;
        }

        /// <summary>
        /// Возвращает строковое представление объекта DateTimeEntityValue.
        /// </summary>
        /// <returns>Строковое представление объекта DateTimeEntityValue.</returns>
        public override string ToString()
        {
            string? yearString = (YearIsRelative == true) ? $"*{Year}" : $"{Year}"; ;
            string? monthString = (MonthIsRelative == true) ? $"*{Month}" : $"{Month}";
            string? dayString = (DayIsRelative == true) ? $"*{Day}" : $"{Day}";
            string? hourString = (HourIsRelative == true) ? $"*{Hour}" : $"{Hour}";
            string? minuteString = (MinuteIsRelative == true) ? $"*{Minute}" : $"{Minute}";

            return $"DateTimeEntityValue: Year: {yearString}, Month: {monthString}, Day: {dayString}, Hour: {hourString}, Minute: {minuteString}";
        }
    }
}