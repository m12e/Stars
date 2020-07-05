using System.Net;
using System.Net.Http;

namespace Stars.Business.Models.Http
{
	/// <summary>
	/// Модель для HTTP-ответа
	/// </summary>
	public class HttpResponseModel
	{
		public HttpResponseModel()
		{
		}

		public HttpResponseModel(HttpResponseMessage httpResponse)
		{
			IsSuccessful = httpResponse.IsSuccessStatusCode;
			StatusCode = httpResponse.StatusCode;
		}

		/// <summary>
		/// Был ли запрос успешным
		/// </summary>
		public bool IsSuccessful { get; set; }

		/// <summary>
		/// Код состояния HTTP
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }
	}
}
