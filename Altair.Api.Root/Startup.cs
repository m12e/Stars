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
using Stars.Business.Modules;
using Stars.Core.Modules;

namespace Altair.Api.Root
{
	public class Startup
	{
		/// <summary>
		/// Название проекта
		/// </summary>
		private const string PROJECT_NAME = "altair";

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddStarsCoreModule()
				.AddStarsLoggerModule(PROJECT_NAME)
				.AddStarsBusinessModule()
				.AddStarsRabbitModule();

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
			app
				.ValidateMapperConfiguration()
				.AddSwagger("Altair API v1")
				.AddExceptionHandling()
				.CreateRabbitConnection();

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
