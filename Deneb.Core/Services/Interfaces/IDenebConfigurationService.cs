namespace Deneb.Core.Services.Interfaces
{
	/// <summary>
	/// Сервис для доступа к конфигурации проектов Deneb
	/// </summary>
	public interface IDenebConfigurationService
	{
		/// <summary>
		/// Строка подключения к базе данных по умолчанию
		/// </summary>
		string DefaultConnectionString { get; }
	}
}
