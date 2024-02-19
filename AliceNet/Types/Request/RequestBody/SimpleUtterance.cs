using System.Text.Json;
using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Навык получает запрос с типом SimpleUtterance, если:
    /// * Пользователь произносит фразу.
    /// * Пользователь нажимает кнопку в бабле из предыдущего ответа навыка(свойство Hide со значением false).
    /// * Пользователь нажимает отдельную кнопку в предыдущем ответе навыка(свойство Hide со значением true) с 
    /// отсутствующим значением в поле Payload.
    /// Пользователь впервые обращается к навыку в контексте сессии.Остальные поля в объекте request в этом случае передаются пустыми.
    /// </summary>
    public class SimpleUtterance : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonPropertyName("type")]
        public IRequestBody.RequestTypes RequestType => IRequestBody.RequestTypes.SimpleUtterance;

        /// <summary>
        /// Нормализованный текст запроса. В ходе нормализации текст очищается от знаков препинания, приводится к нижнему регистру, 
        /// а числительные преобразуются в числа. При запуске навыка
        /// запросу вида «Спроси у навыка {Название} сколько времени» в command придет только правая часть запроса: «сколько времени».
        /// Чтобы получить точный текст запроса, используйте свойство OriginalUtterance.
        /// </summary>
        [JsonPropertyName("command")]
        public string Command { get; }

        /// <summary>
        /// Полный текст пользовательского запроса, максимум 1024 символа.
        /// Если свойство содержит значение ping, то запрос выполняется Диалогами и является проверочным.
        /// </summary>
        [JsonPropertyName("original_utterance")]
        public string OriginalUtterance { get; }

        /// <summary>
        /// Формальные характеристики реплики, которые удалось выделить Яндекс Диалогам. 
        /// Свойство отсутствует, если ни одно из вложенных свойств не применимо.
        /// </summary>
        [JsonPropertyName("markup")]
        public Markup? Markup { get; }

        /// <summary>
        /// Слова и именованные сущности, которые Диалоги извлекли из запроса пользователя.
        /// </summary>
        [JsonPropertyName("nlu")]
        public Nlu Nlu { get; }

        /// <summary>
        /// Дополнительные данные, которые Диалоги получили от навыка вместе с запросом пользователя (нажатие кнопки, ввод текста и т. п.).
        /// </summary>
        [JsonPropertyName("payload")]
        public JsonElement? Payload { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public SimpleUtterance(string command, string originalUtterance, Markup? markup, Nlu nlu, JsonElement? payload)
        {
            Command = command;
            OriginalUtterance = originalUtterance;
            Markup = markup;
            Nlu = nlu;
            Payload = payload;
        }

        /// <summary>
        /// Возвращает строковое представление объекта SimpleUtterance.
        /// </summary>
        /// <returns>Строковое представление объекта SimpleUtterance.</returns>
        public override string ToString() => $"Command: {Command}, OriginalUtterance: {OriginalUtterance}";
    }
}
