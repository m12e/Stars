namespace Vega.Api.Dto.UserAccount
{
	/// <summary>
	/// DTO с результатом проверки, существует ли учётная запись пользователя
	/// </summary>
	public class UserAccountIsExistingResponseDto
	{
		/// <summary>
		/// Существует ли учётная запись пользователя
		/// </summary>
		public bool IsUserAccountExisting { get; set; }
	}
}
