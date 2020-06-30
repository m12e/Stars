using Microsoft.EntityFrameworkCore;
using Stars.Dal.DomainModels.Interfaces;
using Stars.Dal.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Stars.Dal.EntityFramework.Repositories
{
	public class DomainRepository<TDomainEntity, TContext> : IDomainRepository<TDomainEntity>
		where TDomainEntity : class, IDomainEntity
		where TContext : DbContext
	{
		private readonly TContext _context;

		public DomainRepository(TContext context)
		{
			_context = context;
		}

		~DomainRepository()
		{
			_context.Dispose();
		}

		public async Task<TDomainEntity[]> GetAllAsync()
		{
			var domainEntities = await _context
				.Set<TDomainEntity>()
				.AsNoTracking()
				.ToArrayAsync();

			return domainEntities;
		}

		public async Task SaveAsync(TDomainEntity domainEntity)
		{
			await _context
				.Set<TDomainEntity>()
				.AddAsync(domainEntity);

			await _context.SaveChangesAsync();
		}
	}
}
