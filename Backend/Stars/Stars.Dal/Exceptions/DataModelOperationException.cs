using Stars.Core.Exceptions;
using System;

namespace Stars.Dal.Exceptions
{
	/// <summary>
	/// Исключение, при котором не удалось выполнить операцию с моделью данных
	/// </summary>
	public class DataModelOperationException : StarsException
	{
		public DataModelOperationException()
		{
		}

		public DataModelOperationException(string message)
			: base(message)
		{
		}

		public DataModelOperationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
