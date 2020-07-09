using Stars.Core.Models.Configuration.Root;

namespace Stars.Core.Models.Configuration
{
	/// <summary>
	/// Корневой раздел конфигурации приложения
	/// </summary>
	public class RootSectionModel
	{
		/// <inheritdoc cref="ConnectionStringsSectionModel"/>
		public ConnectionStringsSectionModel ConnectionStrings { get; private set; }

		/// <inheritdoc cref="RabbitSectionModel"/>
		public RabbitSectionModel Rabbit { get; private set; }

		/// <inheritdoc cref="VegaSectionModel"/>
		public VegaSectionModel Vega { get; private set; }

		/// <inheritdoc cref="LoggingSectionModel"/>
		public LoggingSectionModel Logging { get; private set; }
	}
}
