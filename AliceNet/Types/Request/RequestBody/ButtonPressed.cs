using System.Text.Json;
using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Нажатие кнопки.
    /// </summary>
    public class ButtonPressed : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonIgnore]
        public IRequestBody.RequestTypes RequestType { get => IRequestBody.RequestTypes.ButtonPressed; }

        /// <summary>
        /// Слова и именованные сущности, которые Диалоги извлекли из запроса пользователя.
        /// </summary>
        [JsonPropertyName("nlu")]
        public Nlu Nlu { get; }

        /// <summary>
        /// JSON-объект, полученный с нажатой кнопкой от обработчика навыка (в ответе на предыдущий запрос).
        /// </summary>
        [JsonPropertyName("payload")]
        public JsonElement Payload { get; }

        /// <summary>
        /// Формальные характеристики реплики, которые удалось выделить Яндекс Диалогам. 
        /// Отсутствует, если ни одно из вложенных свойств не применимо.
        /// </summary>
        [JsonPropertyName("markup")]
        public Markup? Markup { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public ButtonPressed(Nlu nlu, JsonElement payload, Markup? markup)
        {
            Nlu = nlu;
            Payload = payload;
            Markup = markup;
        }

        /// <summary>
        /// Возвращает строковое представление объекта ButtonPressed.
        /// </summary>
        /// <returns>Строковое представление объекта ButtonPressed.</returns>
        public override string ToString() => "ButtonPressed";
    }
}
