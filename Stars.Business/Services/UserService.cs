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
	public class UserService : IUserService
	{
		private readonly IStarsLogger _logger;
		private readonly IStarsConfigurationService _starsConfigurationService;
		private readonly IHttpService _httpService;

		public UserService(
			IStarsLogger logger,
			IStarsConfigurationService starsConfigurationService,
			IHttpService httpService)
		{
			_logger = logger;
			_starsConfigurationService = starsConfigurationService;
			_httpService = httpService;
		}

		public async Task<bool> AreCredentialsValidAsync(UserCredentialsModel userCredentialsModel)
		{
			var userCredentialsLogText = $"user credentials with login '{userCredentialsModel.Login}'";

			_logger.Information($"Checking if {userCredentialsLogText} are valid...");

			var vegaEndpoint = _starsConfigurationService.Root.Vega.Endpoint;
			if (string.IsNullOrEmpty(vegaEndpoint))
			{
				throw new ConfigurationParameterException("Vega endpoint is null or empty");
			}

			var uri = vegaEndpoint.AddQueryPath(StarsApiConstants.Vega.USER_ACCOUNT_ARE_CREDENTIALS_VALID);

			var requestDto = new UserAreCredentialsValidRequestDto
			{
				Login = userCredentialsModel.Login,
				PasswordHashBase64 = userCredentialsModel.Password.GetSHA256().ToBase64()
			};

			var requestModel = new HttpRequestModel
			{
				Method = HttpMethod.Post,
				Uri = uri,
				Body = requestDto
			};

			var response = await _httpService.SendRequestAsync<UserAreCredentialsValidResponseDto>(requestModel);
			if (!response.IsSuccessful)
			{
				throw new InterserviceApiException($"Request to Vega API failed (uri = '{uri}')");
			}

			if (response.Body.AreUserCredentialsValid)
			{
				_logger.Information($"Check has been completed, {userCredentialsLogText} are valid");
			}
			else
			{
				_logger.Information($"Check has been completed, {userCredentialsLogText} are not valid");
			}

			return response.Body.AreUserCredentialsValid;
		}
	}
}
