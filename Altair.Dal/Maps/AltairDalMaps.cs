using Altair.Core.Models;
using Altair.Dal.DomainModels;
using AutoMapper;

namespace Altair.Dal.Maps
{
	public static class AltairDalMaps
	{
		public static IMapperConfigurationExpression AddAltairDalMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<ParticipantModel, ParticipantDomainModel>().ReverseMap();

			return configuration;
		}
	}
}
