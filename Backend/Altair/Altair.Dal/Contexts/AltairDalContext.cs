using Altair.Dal.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Altair.Dal.Contexts
{
	public class AltairDalContext : DbContext
	{
		public AltairDalContext(DbContextOptions<AltairDalContext> options)
			: base(options)
		{
		}

		public DbSet<ParticipantDataModel> Participants { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
