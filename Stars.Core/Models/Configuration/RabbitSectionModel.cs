namespace Stars.Core.Models.Configuration
{
	/// <summary>
	/// Раздел конфигурации приложения с настройками RabbitMQ
	/// </summary>
	public class RabbitSectionModel
	{
		/// <summary>
		/// Адрес сервера с RabbitMQ
		/// </summary>
		public string HostName { get; private set; }

		/// <summary>
		/// Порт, на котором работает RabbitMQ
		/// </summary>
		public int Port { get; private set; }
	}
}
