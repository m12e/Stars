using System.Collections.Generic;
using System.Net.Http;

namespace Stars.Business.Models.Http
{
	/// <summary>
	/// Модель для HTTP-запроса
	/// </summary>
	public class HttpRequestModel
	{
		/// <summary>
		/// Метод HTTP
		/// </summary>
		public HttpMethod Method { get; set; }

		/// <summary>
		/// Адрес, на который будет отправлен запрос
		/// </summary>
		public string Uri { get; set; }

		/// <summary>
		/// Заголовки
		/// </summary>
		public Dictionary<string, string> Headers { get; set; }
			= new Dictionary<string, string>();

		/// <summary>
		/// Тело с данными
		/// </summary>
		public object Body { get; set; }
	}
}
