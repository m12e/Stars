using System;

namespace Stars.Core.Exceptions
{
	/// <summary>
	/// Базовый класс для исключения в проектах Stars
	/// </summary>
	public abstract class StarsException : Exception
	{
		protected StarsException()
		{
		}

		protected StarsException(string message)
			: base(message)
		{
		}

		protected StarsException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
