﻿using Deneb.Api.Root.Modules;
using Deneb.Dal.Modules;
using Deneb.Mq.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Root.Extensions;
using Stars.Api.Root.Modules;
using Stars.Business.Enums;
using Stars.Business.Modules;
using Stars.Core.Modules;
using Stars.Core.Services.Interfaces;
using Stars.Mq.Modules;

namespace Deneb.Api.Root
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddStarsCoreModule()
				.AddStarsLoggerModule()
				.AddStarsRabbitModule()
				.AddStarsMqModule()
				.AddStarsCorsModule();

			services
				.AddDenebMqModule()
				.AddDenebDalModule()
				.AddDenebMapperModule();

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
				.AddSwagger("Deneb API v1")
				.AddExceptionHandling()
				.SubscribeToRabbitQueue(InterserviceQueueTypeEnum.Deneb)
				.AddCors();

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
