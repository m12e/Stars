using Microsoft.Extensions.Logging;
using Serilog;
using Stars.Core.Exceptions;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using System;

namespace Stars.Core.Logger
{
	public class StarsLogger : IStarsLogger
	{
		public void Trace(string message)
		{
			Log.Logger.Verbose(message);
		}

		public void Debug(string message)
		{
			Log.Logger.Debug(message);
		}

		public void Information(string message)
		{
			Log.Logger.Information(message);
		}

		public void Warning(string message)
		{
			Log.Logger.Warning(message);
		}

		public void Error(string message)
		{
			Log.Logger.Error(message);
		}

		public void Critical(string message)
		{
			Log.Logger.Fatal(message);
		}

		public void Write(string message, LogLevel logLevel)
		{
			var mappedLogLevel = logLevel.ToSerilogLevel();

			Log.Logger.Write(mappedLogLevel, message);
		}

		public void Write(Exception exception)
		{
			var logLevel = exception is CriticalException
				? LogLevel.Critical
				: LogLevel.Error;

			Write(exception.Message, logLevel);
		}
	}
}
