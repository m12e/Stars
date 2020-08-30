using Stars.Business.Enums;
using System.Threading.Tasks;

namespace Stars.Mq.MessageConsumers.Interfaces
{
	/// <summary>
	/// Подписчик на сообщения при внутренней коммуникации между приложениями
	/// </summary>
	public interface IInterserviceMessageConsumer
	{
		/// <summary>
		/// Тип сообщения
		/// </summary>
		InterserviceMessageTypeEnum MessageType { get; }

		/// <summary>
		/// Обработать сообщение
		/// </summary>
		Task ConsumeAsync(string messageJson);
	}
}
