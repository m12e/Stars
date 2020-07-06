namespace Stars.Core.Models.Configuration
{
	/// <summary>
	/// Раздел конфигурации приложения со строками подключения к базам данных
	/// </summary>
	public class ConnectionStringsSectionModel
	{
		/// <summary>
		/// Строка подключения к базе данных по умолчанию
		/// </summary>
		public string Default { get; private set; }
	}
}
