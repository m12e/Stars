namespace Stars.Business.Models.User
{
	/// <summary>
	/// Модель для аутентификации пользователя
	/// </summary>
	public class UserIdentityModel
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
