using Microsoft.Extensions.DependencyInjection;
using Stars.Business.Services;
using Stars.Business.Services.Interfaces;

namespace Stars.Business.Modules
{
	public static class StarsBusinessModule
	{
		public static IServiceCollection AddStarsBusinessModule(this IServiceCollection services)
		{
			// HTTP-клиенты
			services
				.AddHttpClient<IHttpService, HttpService>();

			// Сервисы
			services
				.AddScoped<IUserService, UserService>();

			return services;
		}
	}
}
