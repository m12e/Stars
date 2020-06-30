using Stars.Dal.DomainModels;

namespace Altair.Dal.DomainModels
{
	/// <summary>
	/// Участник
	/// </summary>
	public class ParticipantDomainModel : BaseDomainModel
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
