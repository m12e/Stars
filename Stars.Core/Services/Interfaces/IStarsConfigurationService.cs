using Stars.Core.Models.Configuration;

namespace Stars.Core.Services.Interfaces
{
	/// <summary>
	/// Сервис для доступа к базовой для всех проектов Stars конфигурации приложения
	/// </summary>
	public interface IStarsConfigurationService : IConfigurationService<RootSectionModel>
	{
	}
}
