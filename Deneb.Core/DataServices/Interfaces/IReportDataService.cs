using Deneb.Core.Models;
using System.Threading.Tasks;

namespace Deneb.Core.DataServices.Interfaces
{
	/// <summary>
	/// Сервис для операций с отчётами
	/// </summary>
	public interface IReportDataService
	{
		/// <summary>
		/// Получить список всех отчётов, упорядоченный по дате создания
		/// </summary>
		Task<ReportModel[]> GetAllOrderedAsync();

		/// <summary>
		/// Сохранить отчёт
		/// </summary>
		/// <returns>Идентификатор созданной записи</returns>
		Task<int> SaveAsync(ReportForSaveModel reportForSaveModel);
	}
}
