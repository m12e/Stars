using Stars.Business.Exceptions;
using Stars.Business.Tests.Services.Fixtures;
using Stars.Core.Exceptions;
using System.Threading.Tasks;
using Xunit;

namespace Stars.Business.Tests.Services
{
	public class UserServiceTests : IClassFixture<UserServiceFixture>
	{
		private readonly UserServiceFixture _userServiceFixture;

		public UserServiceTests(UserServiceFixture userServiceFixture)
		{
			_userServiceFixture = userServiceFixture;
		}

		[Fact]
		public async Task TestAreCredentialsValidAsync_Should_Throw_Exception_When_Vega_Host_Name_Is_Null()
		{
			var userService = _userServiceFixture.CreateUserServiceWithNullVegaHostName();

			await Assert.ThrowsAsync<ConfigurationParameterException>(async () =>
			{
				await userService.AreCredentialsValidAsync(_userServiceFixture.UserCredentials);
			});
		}

		[Fact]
		public async Task TestAreCredentialsValidAsync_Should_Throw_Exception_When_Http_Request_Is_Failed()
		{
			var userService = _userServiceFixture.CreateUserServiceWithFailedHttpRequest();

			await Assert.ThrowsAsync<InterserviceApiException>(async () =>
			{
				await userService.AreCredentialsValidAsync(_userServiceFixture.UserCredentials);
			});
		}

		[Fact]
		public async Task TestAreCredentialsValidAsync_Should_Return_Result()
		{
			var userService = _userServiceFixture.CreateUserService();
			var expectedResult = _userServiceFixture.AreUserCredentialsValid;

			var actualResult = await userService.AreCredentialsValidAsync(_userServiceFixture.UserCredentials);

			Assert.Equal(expectedResult, actualResult);
		}
	}
}
