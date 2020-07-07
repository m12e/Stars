using Stars.Core.Exceptions;
using System;

namespace Stars.Dal.Exceptions
{
	/// <summary>
	/// Исключение, при котором не удалось найти в базе данных запрашиваемую доменную модель
	/// </summary>
	public class DomainModelNotFoundException : BusinessException
	{
		public DomainModelNotFoundException()
		{
		}

		public DomainModelNotFoundException(string message)
			: base(message)
		{
		}

		public DomainModelNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
