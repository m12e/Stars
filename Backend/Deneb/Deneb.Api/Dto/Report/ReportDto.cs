using System;

namespace Deneb.Api.Dto.Report
{
	/// <summary>
	/// DTO с отчётом
	/// </summary>
	public class ReportDto
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
