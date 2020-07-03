using RabbitMQ.Client;
using Stars.Business.Enums;
using System;

namespace Stars.Business.Extensions
{
	/// <summary>
	/// Методы расширения для операций, связанных с RabbitMQ
	/// </summary>
	public static class RabbitExtensions
	{
		/// <summary>
		/// Инициализировать очередь сообщений
		/// </summary>
		public static QueueDeclareOk QueueDeclare(this IModel channelModel, InterserviceQueueTypeEnum queueType)
		{
			var queueName = Enum.GetName(typeof(InterserviceQueueTypeEnum), queueType);
			var queueDeclareResult = channelModel.QueueDeclare(queueName, false, false, false, null);

			return queueDeclareResult;
		}
	}
}
