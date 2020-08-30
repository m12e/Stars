using Microsoft.Extensions.DependencyInjection;
using Stars.Business.Services;
using Stars.Business.Services.Interfaces;

namespace Stars.Business.Modules
{
	public static class StarsRabbitModule
	{
		public static IServiceCollection AddStarsRabbitModule(this IServiceCollection services)
		{
			services
				.AddSingleton<IRabbitConnectionService, RabbitConnectionService>()
				.AddScoped<IRabbitPublicationService, RabbitPublicationService>();

			return services;
		}
	}
}
