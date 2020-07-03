using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace Stars.Core.Extensions
{
	/// <summary>
	/// Методы расширения для сериализации объектов в JSON
	/// </summary>
	public static class JsonExtensions
	{
		/// <summary>
		/// Настройки сериализации
		/// </summary>
		private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
		{
			Culture = CultureInfo.InvariantCulture,
			Formatting = Formatting.None,
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		};

		/// <summary>
		/// Настройки парсинга в JObject
		/// </summary>
		private static readonly JsonLoadSettings _jsonLoadSettings = new JsonLoadSettings
		{
		};

		/// <summary>
		/// Сериализовать объект в строку JSON
		/// </summary>
		public static string ToJson(this object entity)
		{
			return JsonConvert.SerializeObject(entity, _jsonSerializerSettings);
		}

		/// <summary>
		/// Преобразовать строку JSON в JObject
		/// </summary>
		public static JObject ToJObject(this string jsonValue)
		{
			return JObject.Parse(jsonValue, _jsonLoadSettings);
		}

		/// <summary>
		/// Десериализовать строку JSON в объект
		/// </summary>
		public static T Deserialize<T>(this string jsonValue)
		{
			return JsonConvert.DeserializeObject<T>(jsonValue, _jsonSerializerSettings);
		}
	}
}
