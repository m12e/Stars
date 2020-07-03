using Microsoft.Extensions.Configuration;
using Stars.Core.Services.Interfaces;

namespace Stars.Core.Services
{
	public class StarsConfigurationService : IStarsConfigurationService
	{
		private const string RabbitSection = "Rabbit";

		private readonly IConfiguration _configuration;

		public StarsConfigurationService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string DefaultConnectionString => _configuration
			.GetConnectionString("Default");

		public string RabbitHostName => _configuration
			.GetSection(RabbitSection)
			.GetValue<string>("HostName");

		public int RabbitPort => _configuration
			.GetSection(RabbitSection)
			.GetValue<int>("Port");
	}
}
