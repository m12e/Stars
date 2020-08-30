using Altair.Api.Root.Modules;
using Altair.Business.Modules;
using Altair.Dal.Modules;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Constants;
using Stars.Api.Handlers;
using Stars.Api.Root.Extensions;
using Stars.Api.Root.Modules;
using Stars.Business.Modules;
using Stars.Core.Modules;
using Stars.Core.Services.Interfaces;

namespace Altair.Api.Root
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddStarsCoreModule()
				.AddStarsLoggerModule()
				.AddStarsBusinessModule()
				.AddStarsRabbitModule()
				.AddStarsCorsModule();

			services
				.AddAltairBusinessModule()
				.AddAltairDalModule()
				.AddAltairMapperModule();

			services
				.AddSwaggerGen();

			services
				.AddControllers();

			services
				.AddAuthentication(AuthenticationSchemeConstants.BASIC)
				.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(AuthenticationSchemeConstants.BASIC, null);
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
				.AddSwagger("Altair API v1")
				.AddExceptionHandling()
				.CreateRabbitConnection()
				.AddCors();

			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Altair works!");
				});

				endpoints.MapControllers();
			});
		}
	}
}
