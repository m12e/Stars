using Serilog;
using Stars.Core.Logger.Interfaces;

namespace Stars.Core.Logger
{
	public class StarsLogger : IStarsLogger
	{
		public void Verbose(string message)
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

		public void Fatal(string message)
		{
			Log.Logger.Fatal(message);
		}
	}
}
