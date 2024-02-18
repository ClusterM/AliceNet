using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Обозначение начала и конца именованной сущности в массиве слов. Нумерация слов в массиве начинается с 0.
    /// </summary>
    public class Tokens
    {
        /// <summary>
        /// Первое слово именованной сущности.
        /// </summary>
        [JsonPropertyName("start")]
        public int Start { get; }

        /// <summary>
        /// Первое слово после именованной сущности.
        /// </summary>
        [JsonPropertyName("end")]
        public int End { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Tokens(int start, int end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Возвращает строковое представление объекта Tokens.
        /// </summary>
        /// <returns>Строковое представление объекта Tokens.</returns>
        public override string ToString() => $"Token: {Start} => {End}";
    }
}
