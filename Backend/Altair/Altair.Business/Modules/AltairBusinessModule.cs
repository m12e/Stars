using Altair.Business.Services;
using Altair.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Altair.Business.Modules
{
	public static class AltairBusinessModule
	{
		public static IServiceCollection AddAltairBusinessModule(this IServiceCollection services)
		{
			// Сервисы
			services
				.AddScoped<IReportService, ReportService>();

			return services;
		}
	}
}
