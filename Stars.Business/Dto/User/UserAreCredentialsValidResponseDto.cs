using Newtonsoft.Json;

namespace Stars.Business.Dto.User
{
	/// <summary>
	/// DTO с результатом проверки, валидны ли учётные данные пользователя
	/// </summary>
	public class UserAreCredentialsValidResponseDto
	{
		/// <summary>
		/// Валидны ли учётные данные пользователя
		/// </summary>
		[JsonProperty("areUserCredentialsValid")]
		public bool AreUserCredentialsValid { get; set; }
	}
}
