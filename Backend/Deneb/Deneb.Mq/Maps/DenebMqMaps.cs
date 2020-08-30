using AutoMapper;
using Deneb.Core.Models;
using Stars.Business.MessageModels;

namespace Deneb.Mq.Maps
{
	public static class DenebMqMaps
	{
		public static IMapperConfigurationExpression AddDenebMqMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<ParticipantReportMessageModel, ReportForSaveModel>();

			return configuration;
		}
	}
}
