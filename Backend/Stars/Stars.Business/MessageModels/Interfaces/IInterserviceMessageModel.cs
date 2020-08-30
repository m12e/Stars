using Stars.Business.Enums;

namespace Stars.Business.MessageModels.Interfaces
{
	/// <summary>
	/// Модель сообщения при внутренней коммуникации между приложениями
	/// </summary>
	public interface IInterserviceMessageModel
	{
		/// <summary>
		/// Тип сообщения
		/// </summary>
		InterserviceMessageTypeEnum MessageType { get; }
	}
}
