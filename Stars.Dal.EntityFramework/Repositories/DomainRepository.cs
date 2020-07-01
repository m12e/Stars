using Microsoft.EntityFrameworkCore;
using Stars.Dal.DomainModels.Interfaces;
using Stars.Dal.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stars.Dal.EntityFramework.Repositories
{
	public class DomainRepository<TDomainModel, TContext> : IDomainRepository<TDomainModel>
		where TDomainModel : class, IDomainModel, new()
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

		public async Task<TDomainModel> GetByIdAsync(int domainModelId)
		{
			var domainModel = await _context
				.Set<TDomainModel>()
				.AsNoTracking()
				.Where(model => model.Id == domainModelId)
				.FirstOrDefaultAsync();

			return domainModel;
		}

		public async Task<TDomainModel[]> GetAllAsync()
		{
			var domainModels = await _context
				.Set<TDomainModel>()
				.AsNoTracking()
				.ToArrayAsync();

			return domainModels;
		}

		public async Task SaveAsync(TDomainModel domainModel)
		{
			await _context
				.Set<TDomainModel>()
				.AddAsync(domainModel);

			await _context.SaveChangesAsync();
		}

		public async Task<int> SaveListAsync(IEnumerable<TDomainModel> domainModels)
		{
			await _context
				.Set<TDomainModel>()
				.AddRangeAsync(domainModels);

			var recordCount = await _context.SaveChangesAsync();

			return recordCount;
		}

		public async Task<bool> DeleteByIdAsync(int domainModelId)
		{
			var domainModel = new TDomainModel
			{
				Id = domainModelId
			};

			_context
				.Set<TDomainModel>()
				.Remove(domainModel);

			try
			{
				await _context.SaveChangesAsync();
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}
