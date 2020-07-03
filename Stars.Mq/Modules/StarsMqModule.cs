using Microsoft.Extensions.DependencyInjection;
using Stars.Mq.Services;
using Stars.Mq.Services.Interfaces;

namespace Stars.Mq.Modules
{
	public static class StarsMqModule
	{
		public static IServiceCollection AddStarsMqModule(this IServiceCollection services)
		{
			// Сервисы
			services
				.AddSingleton<IRabbitConsumptionService, RabbitConsumptionService>();

			return services;
		}
	}
}
