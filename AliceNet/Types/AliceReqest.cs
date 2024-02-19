using System.Text.Json.Serialization;
using wtf.cluster.AliceNet.Types.Request;
using wtf.cluster.AliceNet.Types.Request.RequestBody;

namespace wtf.cluster.AliceNet.Types
{
    /// <summary>
    /// Запрос, который Алиса отправляет навыку.
    /// </summary>
    public class AliceReqest
    {
        /// <summary>
        /// Информация об устройстве, с помощью которого пользователь разговаривает с Алисой.
        /// </summary>
        [JsonPropertyName("meta")]
        public Meta Meta { get; }

        /// <summary>
        /// Данные, полученные от пользователя.
        /// </summary>
        [JsonPropertyName("request")]
        public IRequestBody RequestBody { get; }

        /// <summary>
        /// Данные о сессии. Сессия — это период относительно непрерывного взаимодействия пользователя с навыком.
        /// Сессия завершается, когда:
        /// * пользователь запрашивает выход из навыка;
        /// * навык явно завершает работу("end_session": true);
        /// * от пользователя долго не поступает команд (тайм-аут зависит от поверхности, минимум несколько минут).
        /// </summary>
        [JsonPropertyName("session")]
        public Session Session { get; }

        /// <summary>
        /// Данные о сохраненном состоянии.
        /// </summary>
        [JsonPropertyName("state")]
        public State State { get; }

        /// <summary>
        /// Версия протокола.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public AliceReqest(Meta meta, IRequestBody requestBody, Session session, State state, string version)
        {
            Meta = meta;
            RequestBody = requestBody;
            Session = session;
            State = state;
            Version = version;
        }

        /// <summary>
        /// Возвращает строковое представление объекта AliceReqest.
        /// </summary>
        /// <returns>Строковое представление объекта AliceReqest.</returns>
        public override string ToString() => $"{RequestBody}";
    }
}
