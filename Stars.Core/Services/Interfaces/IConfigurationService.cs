namespace Stars.Core.Services.Interfaces
{
	/// <summary>
	/// Сервис для доступа к конфигурации приложения
	/// </summary>
	public interface IConfigurationService<TRootSectionModel>
	{
		/// <summary>
		/// Корневой раздел конфигурации приложения
		/// </summary>
		public TRootSectionModel Root { get; }
	}
}
