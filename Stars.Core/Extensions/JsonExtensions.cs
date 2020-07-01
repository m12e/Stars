using Newtonsoft.Json;
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
		/// Сериализовать объект в JSON
		/// </summary>
		public static string ToJson(this object entity)
		{
			return JsonConvert.SerializeObject(entity, _jsonSerializerSettings);
		}
	}
}
