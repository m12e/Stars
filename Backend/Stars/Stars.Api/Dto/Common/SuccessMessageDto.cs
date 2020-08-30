namespace Stars.Api.Dto.Common
{
	/// <summary>
	/// DTO с сообщением об успешно выполненной операции
	/// </summary>
	public class SuccessMessageDto
	{
		/// <summary>
		/// Сообщение об успешно выполненной операции
		/// </summary>
		public string SuccessMessage { get; set; } = "OK";
	}
}
