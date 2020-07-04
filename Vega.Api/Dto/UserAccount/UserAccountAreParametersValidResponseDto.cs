namespace Vega.Api.Dto.UserAccount
{
	/// <summary>
	/// DTO с результатом проверки, валидны ли параметры учётной записи пользователя
	/// </summary>
	public class UserAccountAreParametersValidResponseDto
	{
		/// <summary>
		/// Валидны ли параметры учётной записи пользователя
		/// </summary>
		public bool AreUserAccountParametersValid { get; set; }
	}
}
