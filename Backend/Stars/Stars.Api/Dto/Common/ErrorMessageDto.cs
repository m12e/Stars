using Newtonsoft.Json;

namespace Stars.Api.Dto.Common
{
	/// <summary>
	/// DTO с сообщением об ошибке
	/// </summary>
	public class ErrorMessageDto
	{
		/// <summary>
		/// Сообщение об ошибке
		/// </summary>
		[JsonProperty("errorMessage")]
		public string ErrorMessage { get; set; }
	}
}
