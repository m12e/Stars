using Stars.Business.Enums;
using Stars.Business.MessageModels.Interfaces;

namespace Stars.Business.MessageModels
{
	/// <summary>
	/// Отчёт об участниках
	/// </summary>
	public class ParticipantReportMessageModel : IInterserviceMessageModel
	{
		public InterserviceMessageTypeEnum MessageType => InterserviceMessageTypeEnum.ParticipantReport;

		/// <summary>
		/// Общее количество участников
		/// </summary>
		public int ParticipantCount { get; set; }
	}
}
