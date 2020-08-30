using Microsoft.Extensions.Logging;
using Stars.Core.Exceptions;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using System;

using ILogger = Serilog.ILogger;

namespace Stars.Core.Logger
{
	/// <summary>
	/// Базовый логгер для проектов Stars
	/// </summary>
	public class StarsLogger : IStarsLogger
	{
		private readonly ILogger _logger;

		public StarsLogger(ILogger logger)
		{
			_logger = logger;
		}

		public void Trace(string message)
		{
			Write(message, LogLevel.Trace);
		}

		public void Debug(string message)
		{
			Write(message, LogLevel.Debug);
		}

		public void Information(string message)
		{
			Write(message, LogLevel.Information);
		}

		public void Warning(string message)
		{
			Write(message, LogLevel.Warning);
		}

		public void Error(string message)
		{
			Write(message, LogLevel.Error);
		}

		public void Critical(string message)
		{
			Write(message, LogLevel.Critical);
		}

		public virtual void Write(string message, LogLevel logLevel)
		{
			var mappedLogLevel = logLevel.ToSerilogLevel();

			_logger.Write(mappedLogLevel, message);
		}

		public void Write(Exception exception)
		{
			var message = exception.Message;
			if (!string.IsNullOrEmpty(exception.StackTrace))
			{
				message += Environment.NewLine + exception.StackTrace;
			}

			var logLevel = exception is CriticalException
				? LogLevel.Critical
				: LogLevel.Error;

			Write(message, logLevel);
		}
	}
}
