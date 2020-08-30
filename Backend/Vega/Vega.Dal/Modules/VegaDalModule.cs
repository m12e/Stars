using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stars.Core.Services.Interfaces;
using Stars.Dal.EntityFramework.Repositories;
using Stars.Dal.EntityFramework.Repositories.Interfaces;
using Vega.Core.DataServices.Interfaces;
using Vega.Dal.Contexts;
using Vega.Dal.DataModels;
using Vega.Dal.DataServices;

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
					optionsBuilder.UseSqlServer(starsConfigurationService.Root.ConnectionStrings.Default);
				});

			// Репозитории
			services
				.AddScoped<
					IQueryableDataRepository<UserAccountDataModel>,
					DataRepository<UserAccountDataModel, VegaDalContext>>();

			// Data-сервисы
			services
				.AddScoped<IUserAccountDataService, UserAccountDataService>();

			return services;
		}
	}
}
