namespace Altair.Api.Dto.Participant
{
	/// <summary>
	/// DTO с кратким описанием участника
	/// </summary>
	public class ParticipantSummaryDto
	{
		/// <summary>
		/// ФИО
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Возраст
		/// </summary>
		public int Age { get; set; }
	}
}
