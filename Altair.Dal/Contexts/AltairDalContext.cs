using Altair.Core.Services.Interfaces;
using Altair.Dal.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Altair.Dal.Contexts
{
	public class AltairDalContext : DbContext
	{
		private readonly IAltairConfigurationService _altairConfigurationService;

		public AltairDalContext(IAltairConfigurationService altairConfigurationService)
		{
			_altairConfigurationService = altairConfigurationService;
		}

		public DbSet<ParticipantDomainModel> Participants { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_altairConfigurationService.DefaultConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
