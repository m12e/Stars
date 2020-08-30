namespace Altair.Core.Models
{
	/// <summary>
	/// Участник
	/// </summary>
	public class ParticipantModel
	{
		/// <summary>
		/// Идентификатор записи в базе данных
		/// </summary>
		public int Id { get; set; }

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

		/// <summary>
		/// ФИО
		/// </summary>
		public string FullName => $"{LastName} {FirstName} {Patronymic}";
	}
}
