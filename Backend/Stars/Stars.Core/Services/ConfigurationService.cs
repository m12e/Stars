using Microsoft.Extensions.Configuration;
using Stars.Core.Services.Interfaces;

namespace Stars.Core.Services
{
	public abstract class ConfigurationService<TRootSectionModel> : IConfigurationService<TRootSectionModel>
	{
		public ConfigurationService(IConfiguration configuration)
		{
			Root = configuration.Get<TRootSectionModel>(binderOptions =>
			{
				binderOptions.BindNonPublicProperties = true;
			});
		}

		public TRootSectionModel Root { get; }
	}
}
