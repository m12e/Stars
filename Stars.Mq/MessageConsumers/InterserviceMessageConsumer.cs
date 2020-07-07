using Stars.Business.Enums;
using Stars.Business.MessageModels.Interfaces;
using Stars.Core.Extensions;
using Stars.Mq.MessageConsumers.Interfaces;
using System.Threading.Tasks;

namespace Stars.Mq.MessageConsumers
{
	/// <summary>
	/// Базовый класс для подписчиков на сообщения при внутренней коммуникации между приложениями
	/// </summary>
	public abstract class InterserviceMessageConsumer<TMessageModel> : IInterserviceMessageConsumer
		where TMessageModel : IInterserviceMessageModel
	{
		public abstract InterserviceMessageTypeEnum MessageType { get; }

		public async Task ConsumeAsync(string messageJson)
		{
			var messageModel = messageJson.FromJson<TMessageModel>();

			await ConsumeAsync(messageModel);
		}

		/// <summary>
		/// Обработать модель сообщения
		/// </summary>
		protected abstract Task ConsumeAsync(TMessageModel messageModel);
	}
}
