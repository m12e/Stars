using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Stars.Core.Extensions;
using Stars.Core.Logger;
using Stars.Core.Logger.Interfaces;
using Stars.Core.Models.Configuration.Root.Logging;
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
				.WriteToElasticsearchIfEnabled(starsConfigurationService.Root.Logging.Elasticsearch, projectName)
				.CreateLogger();

			services.AddSingleton<IStarsLogger, StarsLogger>();

			return services;
		}

		/// <summary>
		/// Сохранять логи в Elasticsearch, если включена соответствующая опция
		/// </summary>
		private static LoggerConfiguration WriteToElasticsearchIfEnabled(
			this LoggerConfiguration loggerConfiguration,
			ElasticsearchSectionModel elasticsearchConfiguration,
			string projectName)
		{
			if (!elasticsearchConfiguration.Enabled)
			{
				return loggerConfiguration;
			}

			return loggerConfiguration.WriteTo.Elasticsearch(
				$"{elasticsearchConfiguration.HostName}:{elasticsearchConfiguration.Port}",
				autoRegisterTemplate: true,
				autoRegisterTemplateVersion: AutoRegisterTemplateVersion.ESv7,
				indexFormat: $"stars-{projectName}-{0:yyyy.MM.dd}");
		}
	}
}
