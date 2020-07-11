using Elasticsearch.Net;
using Nest;
using Serilog;
using Stars.Core.Exceptions;
using Stars.Core.Services.Interfaces;
using System;

namespace Stars.Core.Services
{
	public class ElasticsearchService : IElasticsearchService
	{
		/// <summary>
		/// Сообщение о регистрации сервиса при отключенной опции в конфигурации приложения
		/// </summary>
		private const string SUPPORT_IS_DISABLED_MESSAGE =
			"Elasticsearch support is disabled in the configuration, but elasticsearch service was registered";

		private readonly ILogger _logger;
		private readonly IStarsConfigurationService _starsConfigurationService;

		private ElasticClient _elasticClient;

		public ElasticsearchService(
			ILogger logger,
			IStarsConfigurationService starsConfigurationService)
		{
			_logger = logger;
			_starsConfigurationService = starsConfigurationService;
		}

		public void CreateClient()
		{
			if (!_starsConfigurationService.Root.Logging.Elasticsearch.Enabled)
			{
				_logger.Fatal(SUPPORT_IS_DISABLED_MESSAGE);

				throw new ElasticsearchException(SUPPORT_IS_DISABLED_MESSAGE);
			}

			var projectName = _starsConfigurationService.Root.Application.Name;
			var hostName = _starsConfigurationService.Root.Logging.Elasticsearch.HostName;
			var port = _starsConfigurationService.Root.Logging.Elasticsearch.Port;

			_logger.Information($"Creating elasticsearch client for server '{hostName}:{port}'...");

			var uri = new Uri($"{hostName}:{port}");
			var connectionPool = new SingleNodeConnectionPool(uri);

			var connectionSettings = new ConnectionSettings(connectionPool)
				.DefaultIndex($"stars-{projectName}")
				.DefaultDisableIdInference()
				.ThrowExceptions();

			_elasticClient = new ElasticClient(connectionSettings);

			_logger.Information($"Elasticsearch client for server '{hostName}:{port}' was successfully created");
		}

		public void IndexDocument<TDocument>(TDocument document)
			where TDocument : class
		{
			if (_elasticClient == null)
			{
				_logger.Error("Elasticsearch client was not created yet");

				return;
			}

			try
			{
				_elasticClient.IndexDocument(document);
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "Error while indexing elasticsearch document");
			}
		}
	}
}
