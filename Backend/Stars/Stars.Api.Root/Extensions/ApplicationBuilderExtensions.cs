﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Stars.Api.Dto.Common;
using Stars.Api.Root.Constants;
using Stars.Business.Enums;
using Stars.Business.Services.Interfaces;
using Stars.Core.Exceptions;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using Stars.Core.Services.Interfaces;
using Stars.Mq.Services.Interfaces;
using System.Net.Mime;

namespace Stars.Api.Root.Extensions
{
	/// <summary>
	/// Методы расширения для конфигурации веб-приложения
	/// </summary>
	public static class ApplicationBuilderExtensions
	{
		/// <summary>
		/// Проверить конфигурацию маппера
		/// </summary>
		public static IApplicationBuilder ValidateMapperConfiguration(this IApplicationBuilder app)
		{
			var mapper = app.ApplicationServices.GetService<IMapper>();
			mapper.ConfigurationProvider.AssertConfigurationIsValid();

			return app;
		}

		/// <summary>
		/// Добавить Swagger
		/// </summary>
		public static IApplicationBuilder AddSwagger(this IApplicationBuilder app, string apiName)
		{
			app.UseSwagger();

			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", apiName);
			});

			return app;
		}

		/// <summary>
		/// Добавить обработку исключений
		/// </summary>
		public static IApplicationBuilder AddExceptionHandling(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(applicationBuilder => {
				applicationBuilder.Run(async httpContext =>
				{
					var exception = httpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error
						?? new UnknownException();

					var exceptionDto = new ErrorMessageDto
					{
						ErrorMessage = exception.Message
					};
					var exceptionJson = exceptionDto.ToJson();

					var logger = applicationBuilder.ApplicationServices.GetService<IStarsLogger>();
					logger.Write(exception);

					httpContext.Response.ContentType = MediaTypeNames.Application.Json;
					httpContext.Response.StatusCode = exception is BusinessException
						? StatusCodes.Status400BadRequest
						: StatusCodes.Status500InternalServerError;

					await httpContext.Response.WriteAsync(exceptionJson);
				});
			});

			return app;
		}

		/// <summary>
		/// Создать клиента для подключения к серверу Elasticsearch
		/// </summary>
		public static IApplicationBuilder CreateElasticsearchClient(this IApplicationBuilder app)
		{
			var elasticsearchService = app.ApplicationServices.GetService<IElasticsearchService>();

			elasticsearchService.CreateClient();

			return app;
		}

		/// <summary>
		/// Создать подключение к серверу RabbitMQ
		/// </summary>
		public static IApplicationBuilder CreateRabbitConnection(this IApplicationBuilder app)
		{
			var rabbitConnectionService = app.ApplicationServices.GetService<IRabbitConnectionService>();

			rabbitConnectionService.CreateConnection();

			return app;
		}

		/// <summary>
		/// Подписаться на очередь сообщений RabbitMQ
		/// </summary>
		public static IApplicationBuilder SubscribeToRabbitQueue(this IApplicationBuilder app, InterserviceQueueTypeEnum queueType)
		{
			var rabbitConsumptionService = app.ApplicationServices.GetService<IRabbitConsumptionService>();

			rabbitConsumptionService.SubscribeToQueue(queueType);

			return app;
		}

		/// <summary>
		/// Добавить настроенный CORS middleware
		/// </summary>
		public static IApplicationBuilder AddCors(this IApplicationBuilder app)
		{
			app.UseCors(CorsPolicyConstants.DEFAULT);

			return app;
		}
	}
}
