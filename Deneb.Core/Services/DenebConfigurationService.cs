using Deneb.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Deneb.Core.Services
{
	public class DenebConfigurationService : IDenebConfigurationService
	{
		private readonly IConfiguration _configuration;

		public DenebConfigurationService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string DefaultConnectionString => _configuration
			.GetConnectionString("Default");
	}
}
