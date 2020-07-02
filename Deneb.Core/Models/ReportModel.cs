using System;

namespace Deneb.Core.Models
{
	/// <summary>
	/// Отчёт
	/// </summary>
	public class ReportModel
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
