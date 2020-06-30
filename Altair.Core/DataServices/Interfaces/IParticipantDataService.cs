using Altair.Core.Models;
using System.Threading.Tasks;

namespace Altair.Core.DataServices.Interfaces
{
	/// <summary>
	/// Сервис для работы с участниками
	/// </summary>
	public interface IParticipantDataService
	{
		/// <summary>
		/// Получить список всех участников
		/// </summary>
		Task<ParticipantModel[]> GetAllAsync();

		/// <summary>
		/// Сохранить участника
		/// </summary>
		/// <returns>Идентификатор созданной записи</returns>
		Task<int> SaveAsync(ParticipantModel participantModel);
	}
}
