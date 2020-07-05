using System;

namespace Stars.Business.Exceptions
{
	/// <summary>
	/// Исключение, связанное со внутренней коммуникацией между приложениями посредством AMQP
	/// </summary>
	public class InterserviceMqException : Exception
	{
		public InterserviceMqException()
		{
		}

		public InterserviceMqException(string message)
			: base(message)
		{
		}

		public InterserviceMqException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
