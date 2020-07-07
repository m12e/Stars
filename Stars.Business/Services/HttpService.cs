using Stars.Business.Models.Http;
using Stars.Business.Services.Interfaces;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Stars.Business.Services
{
	public class HttpService : IHttpService
	{
		private readonly IStarsLogger _logger;
		private readonly HttpClient _httpClient;

		public HttpService(
			IStarsLogger logger,
			HttpClient httpClient)
		{
			_logger = logger;
			_httpClient = httpClient;
		}

		public async Task<HttpResponseModel> SendRequestAsync(HttpRequestModel requestModel)
		{
			using var httpResponse = await SendRequestCoreAsync(requestModel);

			return new HttpResponseModel(httpResponse);
		}

		public async Task<HttpResponseWithBodyModel<T>> SendRequestAsync<T>(HttpRequestModel requestModel)
		{
			using var httpResponse = await SendRequestCoreAsync(requestModel);

			if (!httpResponse.IsSuccessStatusCode)
			{
				return new HttpResponseWithBodyModel<T>(httpResponse);
			}

			_logger.Debug("Reading HTTP response body...");

			using var httpResponseBodyStream = await httpResponse.Content.ReadAsStreamAsync();
			var httpResponseBody = httpResponseBodyStream.FromJson<T>();

			_logger.Information($"HTTP response body was successfully read ({httpResponseBody.ToJson()})");

			return new HttpResponseWithBodyModel<T>(httpResponse)
			{
				Body = httpResponseBody
			};
		}

		/// <summary>
		/// Отправить HTTP-запрос (core-метод)
		/// </summary>
		private async Task<HttpResponseMessage> SendRequestCoreAsync(HttpRequestModel requestModel)
		{
			var httpRequestLogText = $"HTTP {requestModel.Method.Method} request to uri '{requestModel.Uri}'";

			_logger.Debug($"Sending {httpRequestLogText}...");

			using var httpRequest = new HttpRequestMessage(requestModel.Method, requestModel.Uri);

			foreach (var httpHeader in requestModel.Headers)
			{
				httpRequest.Headers.Add(httpHeader.Key, httpHeader.Value);
			}

			if (requestModel.Body != null)
			{
				var httpRequestBodyJson = requestModel.Body.ToJson();
				httpRequest.Content = new StringContent(httpRequestBodyJson, Encoding.UTF8, MediaTypeNames.Application.Json);

				_logger.Verbose($"HTTP request body = '{httpRequestBodyJson}'");
			}

			var httpResponse = await _httpClient.SendAsync(httpRequest);
			if (httpResponse.IsSuccessStatusCode)
			{
				_logger.Information($"{httpRequestLogText} was successfully sent");
			}
			else
			{
				_logger.Warning($"{httpRequestLogText} failed (status code = '{httpResponse.StatusCode}')");
			}

			return httpResponse;
		}
	}
}
