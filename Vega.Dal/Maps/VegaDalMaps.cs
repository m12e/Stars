using AutoMapper;
using Vega.Core.Models;
using Vega.Dal.DomainModels;

namespace Vega.Dal.Maps
{
	public static class VegaDalMaps
	{
		public static IMapperConfigurationExpression AddVegaDalMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<UserAccountDomainModel, UserAccountModel>();

			return configuration;
		}
	}
}
