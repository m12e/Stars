using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stars.Api.Constants;
using Stars.Business.Constants;
using Stars.Business.Models.User;
using Stars.Business.Services.Interfaces;
using Stars.Core.Extensions;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Stars.Api.Handlers
{
	/// <summary>
	/// Обработчик для базовой аутентификации пользователя
	/// </summary>
	public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
	{
		private readonly IUserService _userService;

		public BasicAuthenticationHandler(
			IOptionsMonitor<AuthenticationSchemeOptions> options,
			ILoggerFactory logger,
			UrlEncoder encoder,
			ISystemClock clock,
			IUserService userService)
			: base(options, logger, encoder, clock)
		{
			_userService = userService;
		}

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			if (!Request.Headers.TryGetValue("Authorization", out var authorizationValues))
			{
				return AuthenticateResult.Fail("Missing authorization header");
			}
			if (!AuthenticationHeaderValue.TryParse(authorizationValues.First(), out var parsedAuthorizationValue))
			{
				return AuthenticateResult.Fail("Invalid authorization header");
			}

			var authenticationScheme = parsedAuthorizationValue.Scheme;
			if (authenticationScheme != AuthenticationSchemeConstants.BASIC)
			{
				return AuthenticateResult.Fail($"Invalid authentication scheme: '{authenticationScheme}'");
			}

			var authorizationParameter = parsedAuthorizationValue.Parameter.FromBase64ToString();
			var userCredentials = authorizationParameter.Split(':');

			if (userCredentials.Length != 2 || userCredentials[0] == "" || userCredentials[1] == "")
			{
				return AuthenticateResult.Fail($"Invalid user credentials");
			}

			var userCredentialsModel = new UserCredentialsModel
			{
				Login = userCredentials[0],
				Password = userCredentials[1]
			};

			var areCredentialsValid = await _userService.AreCredentialsValidAsync(userCredentialsModel);
			if (!areCredentialsValid)
			{
				return AuthenticateResult.Fail($"Invalid user login or password");
			}

			var userClaims = new[]
			{
				new Claim(ClaimTypes.Name, userCredentialsModel.Login),
				new Claim(ClaimTypes.Role, StarsUserRoleConstants.USER),
				new Claim(ClaimTypes.AuthenticationMethod, authenticationScheme)
			};
			var claimsIdentity = new ClaimsIdentity(userClaims, authenticationScheme);
			var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
			var authenticationTicket = new AuthenticationTicket(claimsPrincipal, authenticationScheme);

			return AuthenticateResult.Success(authenticationTicket);
		}
	}
}
