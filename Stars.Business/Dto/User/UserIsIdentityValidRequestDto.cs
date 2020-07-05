using Newtonsoft.Json;

namespace Stars.Business.Dto.User
{
	/// <summary>
	/// DTO для проверки, валидны ли параметры аутентификации пользователя
	/// </summary>
	public class UserIsIdentityValidRequestDto
	{
		/// <summary>
		/// Логин
		/// </summary>
		[JsonProperty("login")]
		public string Login { get; set; }

		/// <summary>
		/// Хеш пароля в формате Base64
		/// </summary>
		[JsonProperty("passwordHashBase64")]
		public string PasswordHashBase64 { get; set; }
	}
}
