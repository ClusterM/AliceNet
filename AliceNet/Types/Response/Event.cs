namespace wtf.cluster.AliceNet.Types.Response
{
    /// <summary>
    /// Событие.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Название события.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// JSON-объект для многоуровневых событий. Допустимо не более пяти уровней вложенности события.
        /// Многоуровневые события передаются через пары key:value.
        /// Подробнее: https://appmetrica.yandex.ru/docs/data-collection/about-events.html
        /// </summary>
        public required object Value { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта Event.
        /// </summary>
        /// <returns>Строковое представление объекта Event.</returns>
        public override string ToString() => $"{Name}: {Value}";
    }
}
