using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Root.Extensions;
using Stars.Api.Root.Modules;
using Stars.Core.Modules;
using Stars.Core.Services.Interfaces;
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
				.AddStarsLoggerModule()
				.AddStarsCorsModule();

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
			var starsConfigurationService = app.ApplicationServices.GetService<IStarsConfigurationService>();

			if (starsConfigurationService.Root.Logging.Elasticsearch.Enabled)
			{
				app.CreateElasticsearchClient();
			}

			app
				.ValidateMapperConfiguration()
				.AddSwagger("Vega API v1")
				.AddExceptionHandling()
				.AddCors();

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
