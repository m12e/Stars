namespace Stars.Core.Models.Configuration.Root.Logging
{
	/// <summary>
	/// Раздел конфигурации приложения с настройками Elasticsearch
	/// </summary>
	public class ElasticsearchSectionModel
	{
		/// <summary>
		/// Включено ли логирование с использованием Elasticsearch
		/// </summary>
		public bool Enabled { get; private set; }

		/// <summary>
		/// Адрес сервера с Elasticsearch
		/// </summary>
		public string HostName { get; private set; }

		/// <summary>
		/// Порт, на котором работает Elasticsearch
		/// </summary>
		public int Port { get; private set; }
	}
}
