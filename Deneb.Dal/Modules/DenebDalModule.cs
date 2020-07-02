using Deneb.Core.DataServices.Interfaces;
using Deneb.Core.Services.Interfaces;
using Deneb.Dal.Contexts;
using Deneb.Dal.DataServices;
using Deneb.Dal.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Stars.Dal.EntityFramework.Repositories;
using Stars.Dal.EntityFramework.Repositories.Interfaces;

namespace Deneb.Dal.Modules
{
	public static class DenebDalModule
	{
		public static IServiceCollection AddDenebDalModule(this IServiceCollection services)
		{
			// Контексты баз данных
			services
				.AddDbContext<DenebDalContext>((serviceProvider, optionsBuilder) =>
				{
					var denebConfigurationService = serviceProvider.GetService<IDenebConfigurationService>();
					optionsBuilder.UseSqlServer(denebConfigurationService.DefaultConnectionString);
				});

			// Репозитории
			services
				.AddTransient<
					IQueryableDomainRepository<ReportDomainModel>,
					DomainRepository<ReportDomainModel, DenebDalContext>>();

			// Data-сервисы
			services
				.AddTransient<IReportDataService, ReportDataService>();

			return services;
		}
	}
}
