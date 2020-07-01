using Altair.Api.Root.Modules;
using Altair.Core.Modules;
using Altair.Dal.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Root.Extensions;
using Stars.Core.Modules;

namespace Altair.Api.Root
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddLoggerModule()
				.AddAltairMapperModule()
				.AddAltairCoreModule()
				.AddAltairDalModule()
				.AddSwaggerGen();

			services
				.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app
				.ValidateMapperConfiguration()
				.AddSwagger("Altair API v1")
				.AddExceptionHandling();

			app.UseRouting();

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
