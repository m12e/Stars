using Newtonsoft.Json;

namespace Stars.Business.Dto.User
{
	/// <summary>
	/// DTO с результатом проверки, валидны ли параметры аутентификации пользователя
	/// </summary>
	public class UserIsIdentityValidResponseDto
	{
		/// <summary>
		/// Валидны ли параметры аутентификации пользователя
		/// </summary>
		[JsonProperty("isUserIdentityValid")]
		public bool IsUserIdentityValid { get; set; }
	}
}
