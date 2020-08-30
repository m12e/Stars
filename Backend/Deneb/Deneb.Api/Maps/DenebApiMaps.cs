using AutoMapper;
using Deneb.Api.Dto.Report;
using Deneb.Core.Models;

namespace Deneb.Api.Maps
{
	public static class DenebApiMaps
	{
		public static IMapperConfigurationExpression AddDenebApiMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<ReportModel, ReportDto>();

			return configuration;
		}
	}
}
