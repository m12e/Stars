﻿using System;

namespace Stars.Business.Exceptions
{
	/// <summary>
	/// Исключение, связанное с RabbitMQ
	/// </summary>
	public class RabbitException : Exception
	{
		public RabbitException()
		{
		}

		public RabbitException(string message)
			: base(message)
		{
		}

		public RabbitException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
