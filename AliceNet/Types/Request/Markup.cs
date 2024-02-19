using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Формальные характеристики реплики, которые удалось выделить Яндекс Диалогам. Свойство отсутствует, если ни одно из вложенных свойств не применимо.
    /// </summary>
    public class Markup
    {
        /// <summary>
        /// Признак реплики, которая содержит криминальный подтекст (самоубийство, разжигание ненависти, угрозы).
        /// Вы можете настроить навык на определенную реакцию для таких случаев 
        /// например, отвечать «Не понимаю, о чем вы. Пожалуйста, переформулируйте вопрос.»
        /// </summary>
        [JsonPropertyName("dangerous_context")]
        public bool DangerousContext { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Markup(bool dangerousContext)
        {
            DangerousContext = dangerousContext;
        }

        /// <summary>
        /// Возвращает строковое представление объекта Markup.
        /// </summary>
        /// <returns>Строковое представление объекта Markup.</returns>
        public override string ToString() => $"DangerousContext: {DangerousContext}";
    }
}
