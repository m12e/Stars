using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Stars.Core.Logger;
using Stars.Core.Logger.Interfaces;

namespace Stars.Core.Modules
{
	/// <summary>
	/// Модуль для регистрации логгера
	/// </summary>
	public static class LoggerModule
	{
		public static IServiceCollection AddLoggerModule(this IServiceCollection services)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.Console()
				.WriteTo.File(
					@"logs\stars.log",
					fileSizeLimitBytes: 10 * 1024 * 1024,
					rollOnFileSizeLimit: true,
					rollingInterval: RollingInterval.Day)
				.CreateLogger();

			services.AddSingleton<IStarsLogger, StarsLogger>();

			return services;
		}
	}
}
