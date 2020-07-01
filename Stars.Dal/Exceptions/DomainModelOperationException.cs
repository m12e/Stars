using System;

namespace Stars.Dal.Exceptions
{
	/// <summary>
	/// Исключение, при котором не удалось выполнить операцию с доменной моделью
	/// </summary>
	public class DomainModelOperationException : Exception
	{
		public DomainModelOperationException()
		{
		}

		public DomainModelOperationException(string message)
			: base(message)
		{
		}

		public DomainModelOperationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
