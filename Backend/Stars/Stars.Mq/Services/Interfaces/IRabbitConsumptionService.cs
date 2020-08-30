using Stars.Business.Enums;

namespace Stars.Mq.Services.Interfaces
{
	/// <summary>
	/// Сервис для подписки на сообщения с использованием RabbitMQ
	/// </summary>
	public interface IRabbitConsumptionService
	{
		/// <summary>
		/// Подписаться на очередь сообщений
		/// </summary>
		void SubscribeToQueue(InterserviceQueueTypeEnum queueType);
	}
}
