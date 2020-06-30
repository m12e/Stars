namespace Altair.Api.Dto
{
	/// <summary>
	/// Базовый DTO для участника
	/// </summary>
	public class ParticipantBaseDto
	{
		/// <summary>
		/// Фамилия
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Имя
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Отчество
		/// </summary>
		public string Patronymic { get; set; }

		/// <summary>
		/// Возраст
		/// </summary>
		public int Age { get; set; }

		/// <summary>
		/// Персональный код
		/// </summary>
		public string PersonalCode { get; set; }
	}
}
