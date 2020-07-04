namespace Vega.Api.Dto.UserAccount
{
	/// <summary>
	/// DTO для создания учётной записи пользователя
	/// </summary>
	public class UserAccountForCreateDto
	{
		/// <summary>
		/// Логин
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; }
	}
}
