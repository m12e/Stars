using System;

namespace Stars.Core.Exceptions
{
	/// <summary>
	/// Базовый класс для исключения, вызванного критической ошибкой
	/// </summary>
	public abstract class CriticalException : StarsException
	{
		protected CriticalException()
		{
		}

		protected CriticalException(string message)
			: base(message)
		{
		}

		protected CriticalException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
