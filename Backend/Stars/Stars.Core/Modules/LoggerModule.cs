using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Stars.Core.Extensions;
using Stars.Core.Logger;
using Stars.Core.Logger.Interfaces;
using Stars.Core.Services;
using Stars.Core.Services.Interfaces;

namespace Stars.Core.Modules
{
	public static class LoggerModule
	{
		/// <summary>
		/// Шаблон для строки с логом
		/// </summary>
		private const string LOG_OUTPUT_TEMPLATE =
			"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}";

		public static IServiceCollection AddStarsLoggerModule(this IServiceCollection services)
		{
			var serviceProvider = services.BuildServiceProvider();
			var starsConfigurationService = serviceProvider.GetService<IStarsConfigurationService>();

			ConfigureLogger(starsConfigurationService);

			services.AddSingleton(Log.Logger);

			if (starsConfigurationService.Root.Logging.Elasticsearch.Enabled)
			{
				services
					.AddSingleton<IElasticsearchService, ElasticsearchService>()
					.AddSingleton<IStarsLogger, StarsElasticsearchLogger>();
			}
			else
			{
				services.AddSingleton<IStarsLogger, StarsLogger>();
			}

			return services;
		}

		private static void ConfigureLogger(IStarsConfigurationService starsConfigurationService)
		{
			var projectName = starsConfigurationService.Root.Application.Name;
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
		}
	}
}
