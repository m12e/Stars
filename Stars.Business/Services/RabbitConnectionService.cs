using RabbitMQ.Client;
using Stars.Business.Exceptions;
using Stars.Business.Services.Interfaces;
using Stars.Core.Logger.Interfaces;
using Stars.Core.Services.Interfaces;

namespace Stars.Business.Services
{
	public class RabbitConnectionService : IRabbitConnectionService
	{
		/// <summary>
		/// Сообщение об отсутствии подключения к серверу
		/// </summary>
		private const string NO_CONNECTION_MESSAGE = "No connection to RabbitMQ server";

		private readonly IStarsLogger _logger;
		private readonly IStarsConfigurationService _starsConfigurationService;

		private IConnection _connection;

		public RabbitConnectionService(
			IStarsLogger logger,
			IStarsConfigurationService starsConfigurationService)
		{
			_logger = logger;
			_starsConfigurationService = starsConfigurationService;
		}

		~RabbitConnectionService()
		{
			_connection?.Dispose();
		}

		public void CreateConnection()
		{
			var hostName = _starsConfigurationService.Root.Rabbit.HostName;
			var port = _starsConfigurationService.Root.Rabbit.Port;

			_logger.Information($"Creating connection to RabbitMQ server '{hostName}:{port}'...");

			var connectionFactory = new ConnectionFactory()
			{
				HostName = hostName,
				Port = port
			};

			_connection?.Dispose();
			_connection = connectionFactory.CreateConnection();

			_logger.Information($"Connection to RabbitMQ server '{hostName}:{port}' was successfully established");
		}

		public IConnection GetConnection(bool createIfNotExists = true)
		{
			_logger.Information("Getting connection to RabbitMQ server...");

			if (_connection == null || !_connection.IsOpen)
			{
				if (createIfNotExists)
				{
					_logger.Warning(NO_CONNECTION_MESSAGE);

					CreateConnection();
				}
				else
				{
					throw new RabbitException(NO_CONNECTION_MESSAGE);
				}
			}

			return _connection;
		}
	}
}
