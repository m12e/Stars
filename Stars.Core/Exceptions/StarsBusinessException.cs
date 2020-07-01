using System;

namespace Stars.Core.Exceptions
{
	/// <summary>
	/// Исключение для проектов Stars, вызванное бизнес-ошибкой
	/// </summary>
	public abstract class StarsBusinessException : Exception
	{
		protected StarsBusinessException()
		{
		}

		protected StarsBusinessException(string message)
			: base(message)
		{
		}

		protected StarsBusinessException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
