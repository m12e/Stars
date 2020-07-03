using RabbitMQ.Client;
using Stars.Business.Enums;
using Stars.Business.Extensions;
using Stars.Business.MessageModels.Interfaces;
using Stars.Business.Services.Interfaces;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using System.Text;

namespace Stars.Business.Services
{
	public class RabbitPublicationService : IRabbitPublicationService
	{
		private readonly IStarsLogger _logger;
		private readonly IRabbitConnectionService _rabbitConnectionService;

		public RabbitPublicationService(
			IStarsLogger logger,
			IRabbitConnectionService rabbitConnectionService)
		{
			_logger = logger;
			_rabbitConnectionService = rabbitConnectionService;
		}

		public void PublishMessage(InterserviceQueueTypeEnum queueType, IInterserviceMessageModel messageModel)
		{
			_logger.Debug($"Publishing interservice message to queue with type = '{queueType}' ({messageModel.ToJson()})...");

			var connection = _rabbitConnectionService.GetConnection();
			using var channelModel = connection.CreateModel();

			var queueDeclareResult = channelModel.QueueDeclare(queueType);

			var messageJson = messageModel.ToJson();
			var messageBytes = Encoding.UTF8.GetBytes(messageJson);

			channelModel.BasicPublish("", queueDeclareResult.QueueName, null, messageBytes);

			_logger.Information($"Interservice message was successfully published to queue with type = '{queueType}'");
		}
	}
}
