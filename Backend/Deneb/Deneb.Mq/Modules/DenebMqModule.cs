using Deneb.Mq.MessageConsumers;
using Microsoft.Extensions.DependencyInjection;
using Stars.Mq.MessageConsumers.Interfaces;

namespace Deneb.Mq.Modules
{
	public static class DenebMqModule
	{
		public static IServiceCollection AddDenebMqModule(this IServiceCollection services)
		{
			// Подписчики
			services
				.AddSingleton<IInterserviceMessageConsumer, ParticipantReportMessageConsumer>();

			return services;
		}
	}
}
