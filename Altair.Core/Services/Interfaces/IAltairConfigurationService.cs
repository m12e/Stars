namespace Altair.Core.Services.Interfaces
{
	/// <summary>
	/// Сервис для доступа к конфигурации проектов Altair
	/// </summary>
	public interface IAltairConfigurationService
	{
		/// <summary>
		/// Строка подключения к базе данных по умолчанию
		/// </summary>
		string DefaultConnectionString { get; }
	}
}
