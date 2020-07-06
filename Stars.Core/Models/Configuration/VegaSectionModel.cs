namespace Stars.Core.Models.Configuration
{
	/// <summary>
	/// Раздел конфигурации приложения с настройками веб-сервиса Vega
	/// </summary>
	public class VegaSectionModel
	{
		/// <summary>
		/// Адрес веб-сервиса Vega
		/// </summary>
		public string Endpoint { get; private set; }
	}
}
