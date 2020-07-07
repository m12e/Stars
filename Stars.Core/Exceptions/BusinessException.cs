using System;

namespace Stars.Core.Exceptions
{
	/// <summary>
	/// Базовый класс для исключения, вызванного бизнес-ошибкой
	/// </summary>
	public abstract class BusinessException : StarsException
	{
		protected BusinessException()
		{
		}

		protected BusinessException(string message)
			: base(message)
		{
		}

		protected BusinessException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
