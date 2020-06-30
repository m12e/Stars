using Altair.Api.Maps;
using Altair.Dal;
using Altair.Dal.Maps;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Altair.Api.Root.Modules
{
	/// <summary>
	/// Модуль для регистрации маппера в проектах Altair
	/// </summary>
	public static class AltairMapperModule
	{
		public static IServiceCollection AddAltairMapperModule(this IServiceCollection services)
		{
			var assemblyMarkers = new[]
			{
				typeof(AltairDalMarker),
				typeof(AltairApiMarker)
			};

			services.AddAutoMapper(configuration =>
			{
				configuration
					.AddAltairDalMaps()
					.AddAltairApiMaps();
			}, assemblyMarkers);

			return services;
		}
	}
}
