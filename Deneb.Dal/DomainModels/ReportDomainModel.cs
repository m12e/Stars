using Stars.Dal.DomainModels;
using System;

namespace Deneb.Dal.DomainModels
{
	/// <summary>
	/// Отчёт
	/// </summary>
	public class ReportDomainModel : BaseDomainModel
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
