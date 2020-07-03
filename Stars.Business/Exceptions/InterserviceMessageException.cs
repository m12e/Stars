using System;

namespace Stars.Business.Exceptions
{
	/// <summary>
	/// Исключение, связанное со внутренней коммуникацией между приложениями
	/// </summary>
	public class InterserviceMessageException : Exception
	{
		public InterserviceMessageException()
		{
		}

		public InterserviceMessageException(string message)
			: base(message)
		{
		}

		public InterserviceMessageException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
