using Microsoft.Extensions.DependencyInjection;
using Stars.Core.Services;
using Stars.Core.Services.Interfaces;

namespace Stars.Core.Modules
{
	public static class StarsCoreModule
	{
		public static IServiceCollection AddStarsCoreModule(this IServiceCollection services)
		{
			// Сервисы
			services
				.AddSingleton<IStarsConfigurationService, StarsConfigurationService>();

			return services;
		}
	}
}
