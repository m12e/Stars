using Altair.Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Altair.Core.Services
{
	public class AltairConfigurationService : IAltairConfigurationService
	{
		private readonly IConfiguration _configuration;

		public AltairConfigurationService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string DefaultConnectionString => _configuration
			.GetConnectionString("Default");
	}
}
