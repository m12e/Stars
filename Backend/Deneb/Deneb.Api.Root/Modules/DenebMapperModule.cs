using AutoMapper;
using Deneb.Api.Maps;
using Deneb.Dal;
using Deneb.Dal.Maps;
using Deneb.Mq.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace Deneb.Api.Root.Modules
{
	public static class DenebMapperModule
	{
		public static IServiceCollection AddDenebMapperModule(this IServiceCollection services)
		{
			var assemblyMarkers = new[]
			{
				typeof(DenebDalMarker),
				typeof(DenebApiMarker)
			};

			services.AddAutoMapper(configuration =>
			{
				configuration
					.AddDenebDalMaps()
					.AddDenebApiMaps()
					.AddDenebMqMaps();
			}, assemblyMarkers);

			return services;
		}
	}
}
