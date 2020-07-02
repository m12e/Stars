using AutoMapper;
using Deneb.Core.Models;
using Deneb.Dal.DomainModels;

namespace Deneb.Dal.Maps
{
	public static class DenebDalMaps
	{
		public static IMapperConfigurationExpression AddDenebDalMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<ReportModel, ReportDomainModel>()
				.ForMember(d => d.Id, o => o.Ignore());

			configuration.CreateMap<ReportDomainModel, ReportModel>();

			return configuration;
		}
	}
}
