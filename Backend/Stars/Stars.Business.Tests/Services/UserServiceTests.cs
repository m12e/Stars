using AutoFixture;
using AutoFixture.Xunit2;
using Stars.Business.Exceptions;
using Stars.Business.Models.User;
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
			var userCredentials = _userServiceFixture.AutoFixture.Create<UserCredentialsModel>();

			await Assert.ThrowsAsync<ConfigurationParameterException>(async () =>
			{
				await userService.AreCredentialsValidAsync(userCredentials);
			});
		}

		[Fact]
		public async Task TestAreCredentialsValidAsync_Should_Throw_Exception_When_Http_Request_Is_Failed()
		{
			var userService = _userServiceFixture.CreateUserServiceWithFailedHttpRequest();
			var userCredentials = _userServiceFixture.AutoFixture.Create<UserCredentialsModel>();

			await Assert.ThrowsAsync<InterserviceApiException>(async () =>
			{
				await userService.AreCredentialsValidAsync(userCredentials);
			});
		}

		[Theory]
		[InlineData("", "")]
		[InlineAutoData]
		public async Task TestAreCredentialsValidAsync_Should_Return_Result(string login, string password)
		{
			var userService = _userServiceFixture.CreateUserService();
			var userCredentials = new UserCredentialsModel
			{
				Login = login,
				Password = password
			};
			var expectedResult = _userServiceFixture.AreUserCredentialsValid;

			var actualResult = await userService.AreCredentialsValidAsync(userCredentials);

			Assert.Equal(expectedResult, actualResult);
		}
	}
}
