using Microsoft.EntityFrameworkCore;
using Stars.Dal.DomainModels.Interfaces;
using Stars.Dal.EntityFramework.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stars.Dal.EntityFramework.Repositories
{
	public class DomainRepository<TDomainModel, TContext> : IQueryableDomainRepository<TDomainModel>
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

		public async Task<int> GetCountAsync()
		{
			var domainModelCount = await _context
				.Set<TDomainModel>()
				.CountAsync();

			return domainModelCount;
		}

		public async Task<TDomainModel> GetByIdAsync(int domainModelId)
		{
			var domainModel = await GetNoTrackingQuery()
				.Where(model => model.Id == domainModelId)
				.FirstOrDefaultAsync();

			return domainModel;
		}

		public async Task<TDomainModel[]> GetAllAsync()
		{
			var domainModels = await GetNoTrackingQuery()
				.ToArrayAsync();

			return domainModels;
		}

		public async Task<bool> SaveAsync(TDomainModel domainModel)
		{
			await _context
				.Set<TDomainModel>()
				.AddAsync(domainModel);

			var recordCount = await SaveContextChangesAsync();

			return recordCount == 1;
		}

		public async Task<int> SaveListAsync(IEnumerable<TDomainModel> domainModels)
		{
			await _context
				.Set<TDomainModel>()
				.AddRangeAsync(domainModels);

			var recordCount = await SaveContextChangesAsync();

			return recordCount;
		}

		public async Task<bool> UpdateAsync(TDomainModel domainModel)
		{
			_context
				.Set<TDomainModel>()
				.Update(domainModel);

			var recordCount = await SaveContextChangesAsync();

			return recordCount == 1;
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

			var recordCount = await SaveContextChangesAsync();

			return recordCount == 1;
		}

		public IQueryable<TDomainModel> GetQuery(bool trackQuery)
		{
			return trackQuery
				? GetTrackingQuery()
				: GetNoTrackingQuery();
		}

		public IQueryable<TDomainModel> GetTrackingQuery()
		{
			return _context
				.Set<TDomainModel>()
				.AsTracking();
		}

		public IQueryable<TDomainModel> GetNoTrackingQuery()
		{
			return _context
				.Set<TDomainModel>()
				.AsNoTracking();
		}

		public async Task<int> SaveContextChangesAsync()
		{
			try
			{
				return await _context.SaveChangesAsync();
			}
			catch
			{
				return 0;
			}
		}
	}
}
