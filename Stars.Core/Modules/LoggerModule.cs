using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
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

		/// <summary>
		/// Словарь для маппинга уровней логирования
		/// </summary>
		private static readonly Dictionary<LogLevel, LogEventLevel> _logLevelDictionary =
			new Dictionary<LogLevel, LogEventLevel>()
			{
				[LogLevel.Trace] = LogEventLevel.Verbose,
				[LogLevel.Debug] = LogEventLevel.Debug,
				[LogLevel.Information] = LogEventLevel.Information,
				[LogLevel.Warning] = LogEventLevel.Warning,
				[LogLevel.Error] = LogEventLevel.Error,
				[LogLevel.Critical] = LogEventLevel.Fatal
			};

		public static IServiceCollection AddStarsLoggerModule(this IServiceCollection services, string projectName)
		{
			var serviceProvider = services.BuildServiceProvider();
			var starsConfigurationService = serviceProvider.GetService<IStarsConfigurationService>();

			var logLevel = starsConfigurationService.Root.Logging.LogLevel.DefaultEnum;

			if (!_logLevelDictionary.TryGetValue(logLevel, out var mappedLogLevel))
			{
				throw new ArgumentException($"Map for logging level '{logLevel}' is not implemented");
			}

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
