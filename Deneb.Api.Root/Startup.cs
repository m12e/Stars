using Deneb.Api.Root.Modules;
using Deneb.Core.Modules;
using Deneb.Dal.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Root.Extensions;
using Stars.Core.Modules;

namespace Deneb.Api.Root
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddLoggerModule()
				.AddDenebMapperModule()
				.AddDenebCoreModule()
				.AddDenebDalModule()
				.AddSwaggerGen();

			services
				.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app
				.ValidateMapperConfiguration()
				.AddSwagger("Deneb API v1")
				.AddExceptionHandling();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Deneb works!");
				});

				endpoints.MapControllers();
			});
		}
	}
}
