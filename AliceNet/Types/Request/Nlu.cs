using System.Text.Json.Serialization;
using wtf.cluster.AliceNet.Types.Request.Entities;

namespace wtf.cluster.AliceNet.Types.Request
{
    /// <summary>
    /// Слова и именованные сущности, которые Диалоги извлекли из запроса пользователя.
    /// </summary>
    public class Nlu
    {
        /// <summary>
        /// Массив слов из пользовательского запроса.
        /// </summary>
        [JsonPropertyName("tokens")]
        public string[] Tokens { get; }

        /// <summary>
        /// Массив именованных сущностей.
        /// </summary>
        [JsonPropertyName("entities")]
        public IEntity[] Entities { get; }

        /// <summary>
        /// Объект с данными, извлеченными из пользовательского запроса.
        /// </summary>
        [JsonPropertyName("intents")]
        public Dictionary<string, Intent> Intents { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public Nlu(string[] tokens, IEntity[] entities, Dictionary<string, Intent> intents)
        {
            Tokens = tokens;
            Entities = entities;
            Intents = intents;
        }
    }
}
