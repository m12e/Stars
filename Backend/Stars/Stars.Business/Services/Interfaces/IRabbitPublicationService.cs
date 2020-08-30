using Stars.Business.Enums;
using Stars.Business.MessageModels.Interfaces;

namespace Stars.Business.Services.Interfaces
{
	/// <summary>
	/// Сервис для публикации сообщений с использованием RabbitMQ
	/// </summary>
	public interface IRabbitPublicationService
	{
		/// <summary>
		/// Опубликовать сообщение
		/// </summary>
		void PublishMessage(InterserviceQueueTypeEnum queueType, IInterserviceMessageModel messageModel);
	}
}
