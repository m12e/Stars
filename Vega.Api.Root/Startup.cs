using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Root.Extensions;
using Stars.Core.Modules;
using Vega.Api.Root.Modules;
using Vega.Dal.Modules;

namespace Vega.Api.Root
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddStarsCoreModule()
				.AddStarsLoggerModule("vega");

			services
				.AddVegaDalModule()
				.AddVegaMapperModule();

			services
				.AddSwaggerGen();

			services
				.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app
				.ValidateMapperConfiguration()
				.AddSwagger("Vega API v1")
				.AddExceptionHandling();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Vega works!");
				});

				endpoints.MapControllers();
			});
		}
	}
}
