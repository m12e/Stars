using AutoMapper;
using Vega.Api.Dto.UserAccount;
using Vega.Core.Models;

namespace Vega.Api.Maps
{
	public static class VegaApiMaps
	{
		public static IMapperConfigurationExpression AddVegaApiMaps(this IMapperConfigurationExpression configuration)
		{
			configuration.CreateMap<UserAccountModel, UserAccountDto>();

			configuration.CreateMap<UserAccountForCreateDto, UserAccountForCreateModel>();

			return configuration;
		}
	}
}
