﻿using Deneb.Api.Root.Modules;
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
		/// <summary>
		/// Название проекта
		/// </summary>
		private const string PROJECT_NAME = "deneb";

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddStarsCoreModule()
				.AddStarsLoggerModule(PROJECT_NAME)
				.AddStarsRabbitModule()
				.AddStarsMqModule();

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
