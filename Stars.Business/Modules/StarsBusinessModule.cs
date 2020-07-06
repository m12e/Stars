using Microsoft.Extensions.DependencyInjection;
using Stars.Business.Services;
using Stars.Business.Services.Interfaces;

namespace Stars.Business.Modules
{
	public static class StarsBusinessModule
	{
		public static IServiceCollection AddStarsBusinessModule(this IServiceCollection services)
		{
			// HTTP-клиент
			services
				.AddHttpClient();

			// Сервисы
			services
				.AddTransient<IStarsHttpService, StarsHttpService>()
				.AddTransient<IUserService, UserService>();

			return services;
		}
	}
}
