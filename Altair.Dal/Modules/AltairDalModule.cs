using Altair.Core.DataServices.Interfaces;
using Altair.Dal.Contexts;
using Altair.Dal.DataServices;
using Altair.Dal.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stars.Core.Services.Interfaces;
using Stars.Dal.EntityFramework.Repositories;
using Stars.Dal.EntityFramework.Repositories.Interfaces;

namespace Altair.Dal.Modules
{
	public static class AltairDalModule
	{
		public static IServiceCollection AddAltairDalModule(this IServiceCollection services)
		{
			// Контексты баз данных
			services
				.AddDbContext<AltairDalContext>((serviceProvider, optionsBuilder) =>
				{
					var altairConfigurationService = serviceProvider.GetService<IStarsConfigurationService>();
					optionsBuilder.UseSqlServer(altairConfigurationService.DefaultConnectionString);
				});

			// Репозитории
			services
				.AddTransient<
					IQueryableDomainRepository<ParticipantDomainModel>,
					DomainRepository<ParticipantDomainModel, AltairDalContext>>();

			// Data-сервисы
			services
				.AddTransient<IParticipantDataService, ParticipantDataService>();

			return services;
		}
	}
}
