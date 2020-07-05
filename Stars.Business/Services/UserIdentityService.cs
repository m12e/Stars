using Stars.Business.Constants;
using Stars.Business.Dto.User;
using Stars.Business.Exceptions;
using Stars.Business.Extensions;
using Stars.Business.Models.Http;
using Stars.Business.Models.User;
using Stars.Business.Services.Interfaces;
using Stars.Core.Exceptions;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using Stars.Core.Services.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stars.Business.Services
{
	public class UserIdentityService : IUserIdentityService
	{
		private readonly IStarsLogger _logger;
		private readonly IStarsConfigurationService _starsConfigurationService;
		private readonly IStarsHttpService _httpService;

		public UserIdentityService(
			IStarsLogger logger,
			IStarsConfigurationService starsConfigurationService,
			IStarsHttpService httpService)
		{
			_logger = logger;
			_starsConfigurationService = starsConfigurationService;
			_httpService = httpService;
		}

		public async Task<bool> IsUserIdentityValidAsync(UserIdentityModel userIdentityModel)
		{
			var userIdentityLogText = $"user identity with login '{userIdentityModel.Login}'";

			_logger.Debug($"Checking if {userIdentityLogText} is valid...");

			var vegaEndpoint = _starsConfigurationService.VegaEndpoint;
			if (string.IsNullOrEmpty(vegaEndpoint))
			{
				throw new ConfigurationParameterException("Vega endpoint is null or empty");
			}

			var uri = vegaEndpoint.AddQueryPath(StarsApiConstants.Vega.USER_ACCOUNT_IS_IDENTITY_VALID);

			var requestDto = new UserIsIdentityValidRequestDto
			{
				Login = userIdentityModel.Login,
				PasswordHashBase64 = userIdentityModel.Password.GetSHA256().ToBase64()
			};

			var requestModel = new HttpRequestModel
			{
				Method = HttpMethod.Post,
				Uri = uri,
				Body = requestDto
			};

			var response = await _httpService.SendRequestAsync<UserIsIdentityValidResponseDto>(requestModel);
			if (!response.IsSuccessful)
			{
				throw new InterserviceApiException($"Request to Vega API failed (uri = '{uri}')");
			}

			if (response.Body.IsUserIdentityValid)
			{
				_logger.Information($"Check has been completed, {userIdentityLogText} is valid");
			}
			else
			{
				_logger.Information($"Check has been completed, {userIdentityLogText} is not valid");
			}

			return response.Body.IsUserIdentityValid;
		}
	}
}
