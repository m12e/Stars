using Microsoft.Extensions.Logging;
using Stars.Core.Extensions;

namespace Stars.Core.Models.Configuration.Root.Logging
{
	/// <summary>
	/// Раздел конфигурации приложения с уровнями логирования
	/// </summary>
	public class LogLevelSectionModel
	{
		/// <summary>
		/// Уровень логирования по умолчанию
		/// </summary>
		public string Default { get; private set; }

		/// <summary>
		/// Уровень логирования по умолчанию (enum)
		/// </summary>
		public LogLevel DefaultEnum => Default.ToEnum<LogLevel>();
	}
}
