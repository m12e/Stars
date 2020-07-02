using Deneb.Core.Services;
using Deneb.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Deneb.Core.Modules
{
	public static class DenebCoreModule
	{
		public static IServiceCollection AddDenebCoreModule(this IServiceCollection services)
		{
			// Сервисы
			services
				.AddTransient<IDenebConfigurationService, DenebConfigurationService>();

			return services;
		}
	}
}
