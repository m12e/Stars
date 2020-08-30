using System.Threading.Tasks;

namespace Altair.Business.Services.Interfaces
{
	/// <summary>
	/// Сервис для операций с отчётами
	/// </summary>
	public interface IReportService
	{
		/// <summary>
		/// Отправить отчёт
		/// </summary>
		Task SendAsync();
	}
}
