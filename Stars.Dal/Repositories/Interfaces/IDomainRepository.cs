using Stars.Dal.DomainModels.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stars.Dal.Repositories.Interfaces
{
	/// <summary>
	/// Доменный репозиторий
	/// </summary>
	public interface IDomainRepository<TDomainModel>
		where TDomainModel : class, IDomainModel, new()
	{
		/// <summary>
		/// Получить доменную модель по идентификатору
		/// </summary>
		Task<TDomainModel> GetByIdAsync(int domainModelId);

		/// <summary>
		/// Получить список всех доменных моделей
		/// </summary>
		Task<TDomainModel[]> GetAllAsync();

		/// <summary>
		/// Сохранить доменную модель
		/// </summary>
		/// <returns>Была ли доменная модель успешно сохранена</returns>
		/// <remarks>Идентификатор записи сохраняется в исходной модели</remarks>
		Task<bool> SaveAsync(TDomainModel domainModel);

		/// <summary>
		/// Сохранить доменные модели
		/// </summary>
		/// <returns>Количество созданных записей</returns>
		Task<int> SaveListAsync(IEnumerable<TDomainModel> domainModels);

		/// <summary>
		/// Обновить данные доменной модели
		/// </summary>
		/// <returns>Была ли доменная модель успешно обновлена</returns>
		Task<bool> UpdateAsync(TDomainModel domainModel);

		/// <summary>
		/// Удалить доменную модель по идентификатору
		/// </summary>
		/// <returns>Была ли доменная модель успешно удалена</returns>
		Task<bool> DeleteByIdAsync(int domainModelId);
	}
}
