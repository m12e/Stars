using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Root.Constants;

namespace Stars.Api.Root.Modules
{
	public static class StarsCorsModule
	{
		public static IServiceCollection AddStarsCorsModule(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy(CorsPolicyConstants.DEFAULT, builder =>
				{
					builder.AllowAnyOrigin();
				});
			});

			return services;
		}
	}
}
