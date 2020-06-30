using Altair.Api.Dto;
using Altair.Core.Models;
using AutoMapper;

namespace Altair.Api.Maps
{
	public static class AltairApiMaps
	{
		public static IMapperConfigurationExpression AddAltairApiMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<ParticipantModel, ParticipantDto>();

			configuration.CreateMap<ParticipantModel, ParticipantSummaryDto>();

			configuration.CreateMap<ParticipantBaseDto, ParticipantModel>()
				.ForMember(d => d.Id, o => o.Ignore());

			return configuration;
		}
	}
}
