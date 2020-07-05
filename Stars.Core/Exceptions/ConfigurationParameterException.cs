using System;

namespace Stars.Core.Exceptions
{
	/// <summary>
	/// Исключение, связанное с параметром конфигурации приложения
	/// </summary>
	public class ConfigurationParameterException : Exception
	{
		public ConfigurationParameterException()
		{
		}

		public ConfigurationParameterException(string message)
			: base(message)
		{
		}

		public ConfigurationParameterException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
