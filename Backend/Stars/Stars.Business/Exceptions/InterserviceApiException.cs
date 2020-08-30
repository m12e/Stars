using Stars.Core.Exceptions;
using System;

namespace Stars.Business.Exceptions
{
	/// <summary>
	/// Исключение, связанное со внутренней коммуникацией между приложениями посредством REST API
	/// </summary>
	public class InterserviceApiException : StarsException
	{
		public InterserviceApiException()
		{
		}

		public InterserviceApiException(string message)
			: base(message)
		{
		}

		public InterserviceApiException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
