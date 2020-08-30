using RabbitMQ.Client;

namespace Stars.Business.Services.Interfaces
{
	/// <summary>
	/// Сервис для подключения к серверу RabbitMQ
	/// </summary>
	public interface IRabbitConnectionService
	{
		/// <summary>
		/// Создать подключение к серверу RabbitMQ
		/// </summary>
		void CreateConnection();

		/// <summary>
		/// Получить модель подключения к серверу RabbitMQ
		/// </summary>
		/// <param name="createIfNotExists">Создать подключение, если его нет</param>
		IConnection GetConnection(bool createIfNotExists = true);
	}
}
