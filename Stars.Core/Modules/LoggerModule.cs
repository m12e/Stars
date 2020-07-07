using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Stars.Core.Extensions;
using Stars.Core.Logger;
using Stars.Core.Logger.Interfaces;
using Stars.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Stars.Core.Modules
{
	public static class LoggerModule
	{
		/// <summary>
		/// Шаблон для строки с логом
		/// </summary>
		private const string LOG_OUTPUT_TEMPLATE =
			"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}";

		public static IServiceCollection AddStarsLoggerModule(this IServiceCollection services, string projectName)
		{
			var serviceProvider = services.BuildServiceProvider();
			var starsConfigurationService = serviceProvider.GetService<IStarsConfigurationService>();

			var logLevel = starsConfigurationService.Root.Logging.LogLevel.DefaultEnum;
			var mappedLogLevel = logLevel.ToSerilogLevel();

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Is(mappedLogLevel)
				.Enrich.WithThreadId()
				.WriteTo.Console(
					outputTemplate: LOG_OUTPUT_TEMPLATE)
				.WriteTo.File(
					$@"logs\{projectName}.log",
					fileSizeLimitBytes: 10 * 1024 * 1024,
					rollOnFileSizeLimit: true,
					rollingInterval: RollingInterval.Day,
					outputTemplate: LOG_OUTPUT_TEMPLATE)
				.CreateLogger();

			services.AddSingleton<IStarsLogger, StarsLogger>();

			return services;
		}
	}
}
