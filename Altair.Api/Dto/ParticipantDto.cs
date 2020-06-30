namespace Altair.Api.Dto
{
	/// <summary>
	/// DTO со всеми данными об участнике
	/// </summary>
	public class ParticipantDto : ParticipantBaseDto
	{
		/// <summary>
		/// Идентификатор записи в базе данных
		/// </summary>
		public int Id { get; set; }
	}
}
