namespace Stars.Core.Services.Interfaces
{
	/// <summary>
	/// Сервис для доступа к конфигурации проектов Stars
	/// </summary>
	public interface IStarsConfigurationService
	{
		/// <summary>
		/// Строка подключения к базе данных по умолчанию
		/// </summary>
		string DefaultConnectionString { get; }

		/// <summary>
		/// Адрес сервера с RabbitMQ
		/// </summary>
		string RabbitHostName { get; }

		/// <summary>
		/// Порт, на котором работает RabbitMQ
		/// </summary>
		int RabbitPort { get; }

		/// <summary>
		/// Адрес веб-сервиса Vega
		/// </summary>
		string VegaEndpoint { get; }
	}
}
