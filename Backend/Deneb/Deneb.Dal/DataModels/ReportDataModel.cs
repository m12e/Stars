using Stars.Dal.DataModels;
using System;

namespace Deneb.Dal.DataModels
{
	/// <summary>
	/// Отчёт
	/// </summary>
	public class ReportDataModel : BaseDataModel
	{
		/// <summary>
		/// Общее количество участников
		/// </summary>
		public int ParticipantCount { get; set; }

		/// <summary>
		/// Дата и время создания отчёта (UTC)
		/// </summary>
		public DateTime DateOfCreationUtc { get; set; }
	}
}
