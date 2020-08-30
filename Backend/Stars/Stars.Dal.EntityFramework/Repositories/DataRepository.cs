using Microsoft.EntityFrameworkCore;
using Stars.Dal.DataModels.Interfaces;
using Stars.Dal.EntityFramework.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stars.Dal.EntityFramework.Repositories
{
	public class DataRepository<TDataModel, TContext> : IQueryableDataRepository<TDataModel>
		where TDataModel : class, IDataModel, new()
		where TContext : DbContext
	{
		private readonly TContext _context;

		public DataRepository(TContext context)
		{
			_context = context;
		}

		public async Task<int> GetCountAsync()
		{
			var dataModelCount = await _context
				.Set<TDataModel>()
				.CountAsync();

			return dataModelCount;
		}

		public async Task<TDataModel> GetByIdAsync(int dataModelId)
		{
			var dataModel = await GetNoTrackingQuery()
				.Where(model => model.Id == dataModelId)
				.FirstOrDefaultAsync();

			return dataModel;
		}

		public async Task<TDataModel[]> GetAllAsync()
		{
			var dataModels = await GetNoTrackingQuery()
				.ToArrayAsync();

			return dataModels;
		}

		public async Task<bool> SaveAsync(TDataModel dataModel)
		{
			await _context
				.Set<TDataModel>()
				.AddAsync(dataModel);

			var recordCount = await SaveContextChangesAsync();

			return recordCount == 1;
		}

		public async Task<int> SaveListAsync(IEnumerable<TDataModel> dataModels)
		{
			await _context
				.Set<TDataModel>()
				.AddRangeAsync(dataModels);

			var recordCount = await SaveContextChangesAsync();

			return recordCount;
		}

		public async Task<bool> UpdateAsync(TDataModel dataModel)
		{
			_context
				.Set<TDataModel>()
				.Update(dataModel);

			var recordCount = await SaveContextChangesAsync();

			return recordCount == 1;
		}

		public async Task<bool> DeleteByIdAsync(int dataModelId)
		{
			var dataModel = new TDataModel
			{
				Id = dataModelId
			};

			_context
				.Set<TDataModel>()
				.Remove(dataModel);

			var recordCount = await SaveContextChangesAsync();

			return recordCount == 1;
		}

		public IQueryable<TDataModel> GetQuery(bool trackQuery)
		{
			return trackQuery
				? GetTrackingQuery()
				: GetNoTrackingQuery();
		}

		public IQueryable<TDataModel> GetTrackingQuery()
		{
			return _context
				.Set<TDataModel>()
				.AsTracking();
		}

		public IQueryable<TDataModel> GetNoTrackingQuery()
		{
			return _context
				.Set<TDataModel>()
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
