using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Vega.Dal.DomainModels;

namespace Vega.Dal.Contexts
{
	public class VegaDalContext : DbContext
	{
		public VegaDalContext(DbContextOptions<VegaDalContext> options)
			: base(options)
		{
		}

		public DbSet<UserAccountDomainModel> UserAccounts { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
