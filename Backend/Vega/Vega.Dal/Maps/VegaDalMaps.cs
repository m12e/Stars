using AutoMapper;
using Vega.Core.Models;
using Vega.Dal.DataModels;

namespace Vega.Dal.Maps
{
	public static class VegaDalMaps
	{
		public static IMapperConfigurationExpression AddVegaDalMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<UserAccountDataModel, UserAccountModel>();

			return configuration;
		}
	}
}
