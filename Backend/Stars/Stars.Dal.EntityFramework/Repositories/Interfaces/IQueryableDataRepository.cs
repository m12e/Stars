using Stars.Dal.DataModels.Interfaces;
using Stars.Dal.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Stars.Dal.EntityFramework.Repositories.Interfaces
{
	/// <summary>
	/// Репозиторий для операций с моделями данных с поддержкой IQueryable
	/// </summary>
	public interface IQueryableDataRepository<TDataModel> : IDataRepository<TDataModel>
		where TDataModel : class, IDataModel, new()
	{
		/// <summary>
		/// Получить запрос для модели данных
		/// </summary>
		/// <param name="trackQuery">Отслеживать ли изменения моделей данных, полученных по запросу</param>
		IQueryable<TDataModel> GetQuery(bool trackQuery);

		/// <summary>
		/// Получить запрос для модели данных с отслеживанием изменений
		/// </summary>
		IQueryable<TDataModel> GetTrackingQuery();

		/// <summary>
		/// Получить запрос для модели данных без отслеживания изменений
		/// </summary>
		IQueryable<TDataModel> GetNoTrackingQuery();

		/// <summary>
		/// Сохранить изменения контекста базы данных
		/// </summary>
		/// <returns>Количество изменённых записей</returns>
		Task<int> SaveContextChangesAsync();
	}
}
