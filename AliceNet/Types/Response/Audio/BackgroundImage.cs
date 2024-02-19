using System.Text.Json.Serialization;

namespace wtf.cluster.AliceNet.Types.Response.Audio
{
    /// <summary>
    /// Фоновое изображение.
    /// </summary>
    public class BackgroundImage
    {
        /// <summary>
        /// Создает новый объект класса BackgroundImage.
        /// </summary>
        /// <param name="url">URL на картинку.</param>
        public BackgroundImage(string url)
        {
            Url = url;
        }

        /// <summary>
        /// URL фонового изображения.
        /// </summary>
        [JsonPropertyName("url")]
        public required string Url { get; set; }

        /// <summary>
        /// Возвращает строковое представление объекта BackgroundImage.
        /// </summary>
        /// <returns>Строковое представление объекта BackgroundImage.</returns>
        public override string ToString() => $"BackgroundImage: {Url}";
    }
}
