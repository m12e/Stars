using Stars.Core.Models.Configuration.Root.Logging;

namespace Stars.Core.Models.Configuration.Root
{
	/// <summary>
	/// Раздел конфигурации приложения с настройками логирования
	/// </summary>
	public class LoggingSectionModel
	{
		/// <inheritdoc cref="LogLevelSectionModel"/>
		public LogLevelSectionModel LogLevel { get; private set; }
	}
}
