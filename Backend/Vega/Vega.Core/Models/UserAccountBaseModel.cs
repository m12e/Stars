namespace Vega.Core.Models
{
	/// <summary>
	/// Базовая модель для учётной записи пользователя
	/// </summary>
	public abstract class UserAccountBaseModel
	{
		/// <summary>
		/// Логин
		/// </summary>
		public string Login { get; set; }
	}
}
