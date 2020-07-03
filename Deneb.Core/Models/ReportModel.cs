using System;

namespace Deneb.Core.Models
{
	/// <summary>
	/// Отчёт
	/// </summary>
	public class ReportModel : ReportForSaveModel
	{
		/// <summary>
		/// Дата и время создания отчёта (UTC)
		/// </summary>
		public DateTime DateOfCreationUtc { get; set; }
	}
}
