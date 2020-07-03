using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stars.Business.Enums;
using Stars.Business.Exceptions;
using Stars.Business.Extensions;
using Stars.Business.MessageModels.Interfaces;
using Stars.Business.Services.Interfaces;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using Stars.Mq.MessageConsumers.Interfaces;
using Stars.Mq.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stars.Mq.Services
{
	public class RabbitConsumptionService : IRabbitConsumptionService
	{
		private readonly IStarsLogger _logger;
		private readonly IRabbitConnectionService _rabbitConnectionService;
		private readonly Dictionary<InterserviceMessageTypeEnum, IInterserviceMessageConsumer> _messageConsumerDictionary;

		private IModel _channelModel;

		public RabbitConsumptionService(
			IStarsLogger logger,
			IRabbitConnectionService rabbitConnectionService,
			IEnumerable<IInterserviceMessageConsumer> messageConsumers)
		{
			_logger = logger;
			_rabbitConnectionService = rabbitConnectionService;
			_messageConsumerDictionary = messageConsumers
				.ToDictionary(messageConsumer => messageConsumer.MessageType);
		}

		~RabbitConsumptionService()
		{
			_channelModel.Dispose();
		}

		public void SubscribeToQueue(InterserviceQueueTypeEnum queueType)
		{
			_logger.Debug($"Subscribing to queue with type '{queueType}'...");

			if (_channelModel == null)
			{
				var connection = _rabbitConnectionService.GetConnection();
				_channelModel = connection.CreateModel();
			}

			var consumer = new EventingBasicConsumer(_channelModel);
			consumer.Received += ProcessReceivedMessageAsync;

			var queueDeclareResult = _channelModel.QueueDeclare(queueType);
			_channelModel.BasicConsume(queueDeclareResult.QueueName, true, consumer);

			_logger.Information($"Successfully subscribed to queue with type '{queueType}'");
		}

		/// <summary>
		/// Обработать полученное сообщение
		/// </summary>
		private async void ProcessReceivedMessageAsync(object model, BasicDeliverEventArgs eventArgs)
		{
			var messageJson = Encoding.UTF8.GetString(eventArgs.Body.ToArray());

			_logger.Debug($"Received interservice message: '{messageJson}'");

			var messageJObject = messageJson.ToJObject();
			var messageTypeName = messageJObject.Value<string>(nameof(IInterserviceMessageModel.MessageType));

			if (!Enum.TryParse<InterserviceMessageTypeEnum>(messageTypeName, out var messageType))
			{
				throw new InterserviceMessageException($"Unknown interservice message type: '{messageTypeName}'");
			}
			if (!_messageConsumerDictionary.TryGetValue(messageType, out var messageConsumer))
			{
				throw new InterserviceMessageException($"Interservice message consumer for type '{messageType}' is not implemented");
			}

			_logger.Debug($"Consuming interservice message with routing key '{eventArgs.RoutingKey}'...");

			await messageConsumer.ConsumeAsync(messageJson);

			_logger.Debug($"Interservice message with routing key '{eventArgs.RoutingKey}' was successfully consumed");
		}
	}
}
