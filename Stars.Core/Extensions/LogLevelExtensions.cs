using Microsoft.Extensions.Logging;
using Serilog.Events;
using System;
using System.Collections.Generic;

namespace Stars.Core.Extensions
{
	/// <summary>
	/// Методы расширения для маппинга уровней логирования
	/// </summary>
	public static class LogLevelExtensions
	{
		/// <summary>
		/// Словарь для маппинга уровней логирования в формат Serilog
		/// </summary>
		private static readonly Dictionary<LogLevel, LogEventLevel> _serilogLevelDictionary =
			new Dictionary<LogLevel, LogEventLevel>()
			{
				[LogLevel.Trace] = LogEventLevel.Verbose,
				[LogLevel.Debug] = LogEventLevel.Debug,
				[LogLevel.Information] = LogEventLevel.Information,
				[LogLevel.Warning] = LogEventLevel.Warning,
				[LogLevel.Error] = LogEventLevel.Error,
				[LogLevel.Critical] = LogEventLevel.Fatal
			};

		/// <summary>
		/// Преобразовать уровень логирования в формат Serilog
		/// </summary>
		public static LogEventLevel ToSerilogLevel(this LogLevel logLevel)
		{
			if (!_serilogLevelDictionary.TryGetValue(logLevel, out var mappedLogLevel))
			{
				throw new NotImplementedException($"Map for logging level '{logLevel}' is not implemented");
			}

			return mappedLogLevel;
		}
	}
}
