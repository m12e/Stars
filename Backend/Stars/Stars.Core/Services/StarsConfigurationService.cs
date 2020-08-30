using Microsoft.Extensions.Configuration;
using Stars.Core.Models.Configuration;
using Stars.Core.Services.Interfaces;

namespace Stars.Core.Services
{
	public class StarsConfigurationService : ConfigurationService<RootSectionModel>, IStarsConfigurationService
	{
		public StarsConfigurationService(IConfiguration configuration)
			: base(configuration)
		{
		}
	}
}
