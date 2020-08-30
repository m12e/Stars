using System.Net.Http;

namespace Stars.Business.Models.Http
{
	/// <summary>
	/// Модель для HTTP-ответа, содержащим тело с данными
	/// </summary>
	public class HttpResponseWithBodyModel<T> : HttpResponseModel
	{
		public HttpResponseWithBodyModel()
		{
		}

		public HttpResponseWithBodyModel(HttpResponseMessage httpResponse)
			: base(httpResponse)
		{
		}

		/// <summary>
		/// Тело с данными
		/// </summary>
		public T Body { get; set; }
	}
}
