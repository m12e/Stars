using AutoMapper;
using Deneb.Core.Models;
using Deneb.Dal.DataModels;

namespace Deneb.Dal.Maps
{
	public static class DenebDalMaps
	{
		public static IMapperConfigurationExpression AddDenebDalMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<ReportDataModel, ReportModel>();

			return configuration;
		}
	}
}
