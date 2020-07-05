using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stars.Core.Services.Interfaces;
using Stars.Dal.EntityFramework.Repositories;
using Stars.Dal.EntityFramework.Repositories.Interfaces;
using Vega.Core.DataServices.Interfaces;
using Vega.Dal.Contexts;
using Vega.Dal.DataServices;
using Vega.Dal.DomainModels;

namespace Vega.Dal.Modules
{
	public static class VegaDalModule
	{
		public static IServiceCollection AddVegaDalModule(this IServiceCollection services)
		{
			// Контексты баз данных
			services
				.AddDbContext<VegaDalContext>((serviceProvider, optionsBuilder) =>
				{
					var starsConfigurationService = serviceProvider.GetService<IStarsConfigurationService>();
					optionsBuilder.UseSqlServer(starsConfigurationService.DefaultConnectionString);
				});

			// Репозитории
			services
				.AddTransient<
					IQueryableDomainRepository<UserAccountDomainModel>,
					DomainRepository<UserAccountDomainModel, VegaDalContext>>();

			// Data-сервисы
			services
				.AddTransient<IUserAccountDataService, UserAccountDataService>();

			return services;
		}
	}
}
