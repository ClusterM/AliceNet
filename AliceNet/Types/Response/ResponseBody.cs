using System.Text.Json.Serialization;
using wtf.cluster.AliceNet.Types.Response.Cards;

namespace wtf.cluster.AliceNet.Types.Response
{
    /// <summary>
    /// Тело ответа, который навык возвращает Алисе.
    /// </summary>
    public class ResponseBody
    {
        /// <summary>
        /// Текст, который следует показать и озвучить пользователю.
        /// Максимум 1024 символа. Может быть пустым (text: ""), если заполнено свойство tts.
        /// Текст также используется, если у Алисы не получилось отобразить включенную в ответ карточку (свойство response.card).
        /// На устройствах, которые поддерживают только голосовое общение с навыком, это будет происходить каждый раз, когда навык присылает карточку в ответе.
        /// </summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        /// <summary>
        /// Ответ в формате TTS (text-to-speech).
        /// Максимум 1024 символа.
        /// Советы по использованию TTS в навыках: https://yandex.ru/dev/dialogs/alice/doc/speech-tuning.html
        /// </summary>
        [JsonPropertyName("tts")]
        public string? Tts { get; set; }

        /// <summary>
        /// Описание карточки — сообщения с поддержкой изображений.
        /// Если приложению удается отобразить карточку для пользователя, свойство response.text не используется.
        /// </summary>
        [JsonPropertyName("card")]
        public ICard? Card { get; set; }

        /// <summary>
        /// Кнопки, которые следует показать пользователю.
        /// </summary>
        [JsonPropertyName("buttons")]
        public Button[]? Buttons { get; set; }

        /// <summary>
        /// Директивы.
        /// </summary>
        [JsonPropertyName("directives")]
        public Directives? Directives { get; set; }

        /// <summary>
        /// Обязательный параметр только для сценария утреннего шоу.
        /// </summary>
        [JsonPropertyName("show_item_meta")]
        public object? ShowItemMeta { get; set; }

        /// <summary>
        /// Признак конца разговора. 
        /// </summary>
        [JsonPropertyName("end_session")]
        public bool EndSession { get; set; } = false;

        /// <summary>
        /// Создает новый объект класса AliceResponse.
        /// </summary>
        public ResponseBody()
        {
        }

        /// <summary>
        /// Создает новый объект класса AliceResponse.
        /// </summary>
        /// <param name="response">Ответ на запрос.</param>
        public ResponseBody(string response)
        {
            Text = response;
        }

        /// <summary>
        /// Возвращает строковое представление объекта AliceResponseBody.
        /// </summary>
        /// <returns>Строковое представление объекта AliceResponseBody.</returns>
        public override string ToString() => Text ?? Tts ?? Card?.ToString() ?? String.Empty;
    }
}
