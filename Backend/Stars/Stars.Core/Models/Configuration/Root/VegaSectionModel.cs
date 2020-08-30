namespace Stars.Core.Models.Configuration.Root
{
	/// <summary>
	/// Раздел конфигурации приложения с настройками веб-сервиса Vega
	/// </summary>
	public class VegaSectionModel
	{
		/// <summary>
		/// Адрес сервера с веб-сервисом Vega
		/// </summary>
		public string HostName { get; private set; }

		/// <summary>
		/// Порт, на котором работает веб-сервис Vega
		/// </summary>
		public int Port { get; private set; }
	}
}
