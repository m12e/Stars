using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Vega.Api.Maps;
using Vega.Dal;
using Vega.Dal.Maps;

namespace Vega.Api.Root.Modules
{
	public static class VegaMapperModule
	{
		public static IServiceCollection AddVegaMapperModule(this IServiceCollection services)
		{
			var assemblyMarkers = new[]
			{
				typeof(VegaDalMarker),
				typeof(VegaApiMarker)
			};

			services.AddAutoMapper(configuration =>
			{
				configuration
					.AddVegaDalMaps()
					.AddVegaApiMaps();
			}, assemblyMarkers);

			return services;
		}
	}
}
