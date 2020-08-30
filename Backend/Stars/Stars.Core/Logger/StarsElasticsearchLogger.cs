using Microsoft.Extensions.Logging;
using Stars.Core.Models.LogMessage;
using Stars.Core.Services.Interfaces;
using System;

using ILogger = Serilog.ILogger;

namespace Stars.Core.Logger
{
	/// <summary>
	/// Логгер для проектов Stars с поддержкой Elasticsearch
	/// </summary>
	public class StarsElasticsearchLogger : StarsLogger
	{
		private readonly IElasticsearchService _elasticsearchService;

		public StarsElasticsearchLogger(
			ILogger logger,
			IElasticsearchService elasticsearchService)
			: base(logger)
		{
			_elasticsearchService = elasticsearchService;
		}

		public override void Write(string message, LogLevel logLevel)
		{
			var logMessage = new LogMessageModel
			{
				Message = message,
				LogLevel = logLevel.ToString(),
				TimeStamp = DateTimeOffset.Now,
				ThreadId = Environment.CurrentManagedThreadId
			};

			_elasticsearchService.IndexDocument(logMessage);

			base.Write(message, logLevel);
		}
	}
}
