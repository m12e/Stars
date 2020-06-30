using Stars.Dal.DomainModels.Interfaces;
using System.Threading.Tasks;

namespace Stars.Dal.Repositories.Interfaces
{
	/// <summary>
	/// Доменный репозиторий
	/// </summary>
	public interface IDomainRepository<TDomainEntity>
		where TDomainEntity : class, IDomainEntity
	{
		/// <summary>
		/// Получить список всех доменных сущностей
		/// </summary>
		Task<TDomainEntity[]> GetAllAsync();

		/// <summary>
		/// Сохранить доменную сущность
		/// </summary>
		Task SaveAsync(TDomainEntity domainEntity);
	}
}
