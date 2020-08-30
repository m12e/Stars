using Stars.Core.Exceptions;
using System;

namespace Stars.Dal.Exceptions
{
	/// <summary>
	/// Исключение, при котором не удалось найти в базе данных запрашиваемые модель
	/// </summary>
	public class DataModelNotFoundException : BusinessException
	{
		public DataModelNotFoundException()
		{
		}

		public DataModelNotFoundException(string message)
			: base(message)
		{
		}

		public DataModelNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
