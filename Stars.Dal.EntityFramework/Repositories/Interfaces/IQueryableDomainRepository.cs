using Stars.Dal.DomainModels.Interfaces;
using Stars.Dal.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Stars.Dal.EntityFramework.Repositories.Interfaces
{
	/// <summary>
	/// Доменный репозиторий с поддержкой IQueryable
	/// </summary>
	public interface IQueryableDomainRepository<TDomainModel> : IDomainRepository<TDomainModel>
		where TDomainModel : class, IDomainModel, new()
	{
		/// <summary>
		/// Получить запрос для доменной модели
		/// </summary>
		/// <param name="trackQuery">Отслеживать ли изменения доменных моделей, полученных по запросу</param>
		IQueryable<TDomainModel> GetQuery(bool trackQuery);

		/// <summary>
		/// Получить запрос для доменной модели с отслеживанием изменений
		/// </summary>
		IQueryable<TDomainModel> GetTrackingQuery();

		/// <summary>
		/// Получить запрос для доменной модели без отслеживания изменений
		/// </summary>
		IQueryable<TDomainModel> GetNoTrackingQuery();

		/// <summary>
		/// Сохранить изменения контекста базы данных
		/// </summary>
		/// <returns>Количество изменённых записей</returns>
		Task<int> SaveContextChangesAsync();
	}
}
