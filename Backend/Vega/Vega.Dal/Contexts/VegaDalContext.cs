using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Vega.Dal.DataModels;

namespace Vega.Dal.Contexts
{
	public class VegaDalContext : DbContext
	{
		public VegaDalContext(DbContextOptions<VegaDalContext> options)
			: base(options)
		{
		}

		public DbSet<UserAccountDataModel> UserAccounts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
