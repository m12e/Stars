using Stars.Core.Exceptions;
using System;

namespace Vega.Core.Exceptions
{
	/// <summary>
	/// Исключение, связанное с учётной записью пользователя
	/// </summary>
	public class UserAccountException : StarsBusinessException
	{
		public UserAccountException()
		{
		}

		public UserAccountException(string message)
			: base(message)
		{
		}

		public UserAccountException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
