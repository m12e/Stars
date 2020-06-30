using Altair.Core.Services;
using Altair.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Altair.Core.Modules
{
	public static class AltairCoreModule
	{
		public static IServiceCollection AddAltairCoreModule(this IServiceCollection services)
		{
			// Сервисы
			services
				.AddTransient<IAltairConfigurationService, AltairConfigurationService>();

			return services;
		}
	}
}
