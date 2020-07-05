namespace Vega.Core.Models
{
	/// <summary>
	/// Модель для создания учётной записи пользователя
	/// </summary>
	public class UserAccountForCreateModel : UserAccountBaseModel
	{
		/// <summary>
		/// Пароль
		/// </summary>
		public string Password { get; set; }
	}
}
