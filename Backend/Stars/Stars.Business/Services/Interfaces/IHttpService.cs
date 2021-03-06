﻿using Stars.Business.Models.Http;
using System.Threading.Tasks;

namespace Stars.Business.Services.Interfaces
{
	/// <summary>
	/// Сервис для отправки HTTP-запросов
	/// </summary>
	public interface IHttpService
	{
		/// <summary>
		/// Отправить HTTP-запрос
		/// </summary>
		Task<HttpResponseModel> SendRequestAsync(HttpRequestModel requestModel);

		/// <summary>
		/// Отправить HTTP-запрос и десериализовать тело ответа
		/// </summary>
		Task<HttpResponseWithBodyModel<T>> SendRequestAsync<T>(HttpRequestModel requestModel);
	}
}
