using System;

namespace Stars.Core.Exceptions
{
	/// <summary>
	/// Исключение, связанное с Elasticsearch
	/// </summary>
	public class ElasticsearchException : StarsException
	{
		public ElasticsearchException()
		{
		}

		public ElasticsearchException(string message)
			: base(message)
		{
		}

		public ElasticsearchException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
