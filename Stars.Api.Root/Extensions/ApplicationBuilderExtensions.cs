using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Stars.Api.Dto.Common;
using Stars.Core.Exceptions;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;

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
					var exception = httpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;
					var exceptionMessage = exception?.Message ?? "Unknown error";
					var exceptionDto = new ErrorMessageDto
					{
						ErrorMessage = exceptionMessage
					};
					var exceptionJson = exceptionDto.ToJson();

					var logger = applicationBuilder.ApplicationServices.GetService<IStarsLogger>();
					logger.Error(exceptionMessage);

					httpContext.Response.ContentType = "application/json";
					httpContext.Response.StatusCode = exception is StarsBusinessException
						? StatusCodes.Status400BadRequest
						: StatusCodes.Status500InternalServerError;

					await httpContext.Response.WriteAsync(exceptionJson);
				});
			});

			return app;
		}
	}
}
