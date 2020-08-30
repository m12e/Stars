namespace Vega.Api.Dto.UserAccount
{
	/// <summary>
	/// DTO для проверки, существует ли учётная запись пользователя
	/// </summary>
	public class UserAccountIsExistingRequestDto
	{
		/// <summary>
		/// Логин
		/// </summary>
		public string Login { get; set; }
	}
}
