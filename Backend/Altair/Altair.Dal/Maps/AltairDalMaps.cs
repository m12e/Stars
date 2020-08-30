using Altair.Core.Models;
using Altair.Dal.DataModels;
using AutoMapper;

namespace Altair.Dal.Maps
{
	public static class AltairDalMaps
	{
		public static IMapperConfigurationExpression AddAltairDalMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<ParticipantModel, ParticipantDataModel>().ReverseMap();

			return configuration;
		}
	}
}
