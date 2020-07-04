namespace Vega.Api.Dto.UserAccount
{
	/// <summary>
	/// DTO для проверки, валидны ли параметры учётной записи пользователя
	/// </summary>
	public class UserAccountAreParametersValidRequestDto
	{
		/// <summary>
		/// Логин
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Хеш пароля в формате Base64
		/// </summary>
		public string PasswordHashBase64 { get; set; }
	}
}
