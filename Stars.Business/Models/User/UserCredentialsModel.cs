namespace Stars.Business.Models.User
{
	/// <summary>
	/// Учётные данные пользователя
	/// </summary>
	public class UserCredentialsModel
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
