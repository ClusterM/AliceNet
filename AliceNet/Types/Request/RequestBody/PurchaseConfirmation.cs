using System.Text.Json.Serialization;
using System.Text.Json;

namespace wtf.cluster.AliceNet.Types.Request.RequestBody
{
    /// <summary>
    /// Навык получает запрос с объектом request и типом Purchase.Confirmation, если пользователь выполняет оплату
    /// и навык должен отправить ему подтверждение.
    /// </summary>
    public class PurchaseConfirmation : IRequestBody
    {
        /// <summary>
        /// Тип запроса.
        /// </summary>
        [JsonPropertyName("type")]
        public IRequestBody.RequestTypes RequestType { get => IRequestBody.RequestTypes.PurchaseConfirmation; }

        /// <summary>
        /// UUID-идентификатор заказа, переданный при запуске сценария оплаты.
        /// </summary>
        [JsonPropertyName("purchase_request_id")]
        public string PurchaseRequestId { get; }

        /// <summary>
        /// UUIDv4-идентификатор транзакции.
        /// </summary>
        [JsonPropertyName("purchase_token")]
        public string PurchaseToken { get; }

        /// <summary>
        /// Идентификатор заказа. Остается неизменным для всех платежей в рамках подписки.
        /// </summary>
        [JsonPropertyName("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// Время совершения оплаты. Равно количеству миллисекунд, прошедших с 01.01.1970 00:00:00 UTC.
        /// </summary>
        [JsonPropertyName("purchase_timestamp")]
        public long PurchaseTimestamp { get; }

        /// <summary>
        /// JSON-объект, полученный при запуске сценария оплаты.
        /// </summary>
        [JsonPropertyName("purchase_payload")]
        public JsonElement PurchasePayload { get; }

        /// <summary>
        /// Строка, использованная для подписи.
        /// </summary>
        [JsonPropertyName("signed_data")]
        public string SignedData { get; }

        /// <summary>
        /// Подпись, полученная путем хеширования значения поля signed_data с помощью алгоритма SHA256 с RSA 
        /// и приватного ключа. Закодирована в base64.
        /// </summary>
        [JsonPropertyName("signature")]
        public string Signature { get; }

        /// <summary>
        /// Конструктор для десериализации из JSON.
        /// </summary>
        [JsonConstructor]
        public PurchaseConfirmation(string purchaseRequestId, string purchaseToken, string orderId, long purchaseTimestamp, JsonElement purchasePayload, string signedData, string signature)
        {
            PurchaseRequestId = purchaseRequestId;
            PurchaseToken = purchaseToken;
            OrderId = orderId;
            PurchaseTimestamp = purchaseTimestamp;
            PurchasePayload = purchasePayload;
            SignedData = signedData;
            Signature = signature;
        }

        /// <summary>
        /// Возвращает строковое представление объекта PurchaseConfirmation.
        /// </summary>
        /// <returns>Строковое представление объекта PurchaseConfirmation.</returns>
        public override string ToString() => $"PurchaseRequestId: {PurchaseRequestId}, PurchaseToken, {PurchaseToken}, OrderId: {OrderId}, PurchaseTimestamp: {PurchaseTimestamp}";
    }
}
