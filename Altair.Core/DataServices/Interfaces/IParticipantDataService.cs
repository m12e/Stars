using Altair.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altair.Core.DataServices.Interfaces
{
	/// <summary>
	/// Сервис для операций с участниками
	/// </summary>
	public interface IParticipantDataService
	{
		/// <summary>
		/// Получить общее количество участников
		/// </summary>
		Task<int> GetCountAsync();

		/// <summary>
		/// Получить участника по идентификатору
		/// </summary>
		Task<ParticipantModel> GetByIdAsync(int participantId);

		/// <summary>
		/// Получить список всех участников
		/// </summary>
		Task<ParticipantModel[]> GetAllAsync();

		/// <summary>
		/// Сохранить участника
		/// </summary>
		/// <returns>Идентификатор созданной записи</returns>
		Task<int> SaveAsync(ParticipantModel participantModel);

		/// <summary>
		/// Сохранить участников
		/// </summary>
		/// <returns>Количество созданных записей</returns>
		Task<int> SaveListAsync(IEnumerable<ParticipantModel> participantModels);

		/// <summary>
		/// Обновить данные участника
		/// </summary>
		Task UpdateAsync(ParticipantModel participantModel);

		/// <summary>
		/// Удалить участника по идентификатору
		/// </summary>
		Task DeleteByIdAsync(int participantId);
	}
}
