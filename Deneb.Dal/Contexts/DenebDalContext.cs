using Deneb.Dal.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Deneb.Dal.Contexts
{
	public class DenebDalContext : DbContext
	{
		public DenebDalContext(DbContextOptions<DenebDalContext> options)
			: base(options)
		{
		}

		public DbSet<ReportDomainModel> Reports { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
