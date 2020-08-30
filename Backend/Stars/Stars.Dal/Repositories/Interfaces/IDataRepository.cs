using Stars.Dal.DataModels.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stars.Dal.Repositories.Interfaces
{
	/// <summary>
	/// Репозиторий для операций с моделями данных
	/// </summary>
	public interface IDataRepository<TDataModel>
		where TDataModel : class, IDataModel, new()
	{
		/// <summary>
		/// Получить общее количество моделей данных
		/// </summary>
		Task<int> GetCountAsync();

		/// <summary>
		/// Получить модель данных по идентификатору
		/// </summary>
		Task<TDataModel> GetByIdAsync(int dataModelId);

		/// <summary>
		/// Получить список всех моделей данных
		/// </summary>
		Task<TDataModel[]> GetAllAsync();

		/// <summary>
		/// Сохранить модель данных
		/// </summary>
		/// <returns>Была ли модель данных успешно сохранена</returns>
		/// <remarks>Идентификатор записи сохраняется в исходной модели</remarks>
		Task<bool> SaveAsync(TDataModel dataModel);

		/// <summary>
		/// Сохранить модели данных
		/// </summary>
		/// <returns>Количество созданных записей</returns>
		Task<int> SaveListAsync(IEnumerable<TDataModel> dataModels);

		/// <summary>
		/// Обновить модель данных
		/// </summary>
		/// <returns>Была ли модель данных успешно обновлена</returns>
		Task<bool> UpdateAsync(TDataModel dataModel);

		/// <summary>
		/// Удалить модель данных по идентификатору
		/// </summary>
		/// <returns>Была ли модель данных успешно удалена</returns>
		Task<bool> DeleteByIdAsync(int dataModelId);
	}
}
