using Deneb.Api.Root.Modules;
using Deneb.Dal.Modules;
using Deneb.Mq.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Root.Extensions;
using Stars.Business.Enums;
using Stars.Business.Modules;
using Stars.Core.Modules;
using Stars.Mq.Modules;

namespace Deneb.Api.Root
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddStarsLoggerModule()
				.AddStarsCoreModule()
				.AddStarsRabbitModule()
				.AddStarsMqModule()
				.AddDenebMqModule()
				.AddDenebDalModule()
				.AddDenebMapperModule()
				.AddSwaggerGen();

			services
				.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app
				.ValidateMapperConfiguration()
				.AddSwagger("Deneb API v1")
				.AddExceptionHandling()
				.SubscribeToRabbitQueue(InterserviceQueueTypeEnum.Deneb);

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
