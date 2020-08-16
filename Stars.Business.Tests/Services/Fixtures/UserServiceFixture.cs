using Moq;
using Stars.Business.Dto.User;
using Stars.Business.Models.Http;
using Stars.Business.Services;
using Stars.Business.Services.Interfaces;
using Stars.Core.Logger.Interfaces;
using Stars.Core.Models.Configuration;
using Stars.Core.Models.Configuration.Root;
using Stars.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Stars.Business.Tests.Services.Fixtures
{
	public class UserServiceFixture : StarsBusinessFixture
	{
		public Mock<IStarsLogger> starsLoggerMock = new Mock<IStarsLogger>();
		public Mock<IStarsConfigurationService> starsConfigurationServiceMock = new Mock<IStarsConfigurationService>();
		public Mock<IHttpService> httpServiceMock = new Mock<IHttpService>();

		public UserService CreateUserService()
		{
			SetupStarsConfigurationServiceMock();
			SetupHttpServiceMock();

			return CreateUserServiceCore();
		}

		public UserService CreateUserServiceWithNullVegaHostName()
		{
			SetupStarsConfigurationServiceMock(null);
			SetupHttpServiceMock();

			return CreateUserServiceCore();
		}

		public UserService CreateUserServiceWithFailedHttpRequest()
		{
			SetupStarsConfigurationServiceMock();
			SetupHttpServiceMock(false);

			return CreateUserServiceCore();
		}

		private UserService CreateUserServiceCore()
		{
			return new UserService(
				starsLoggerMock.Object,
				starsConfigurationServiceMock.Object,
				httpServiceMock.Object);
		}

		private void SetupStarsConfigurationServiceMock(string vegaHostName = "http://localhost")
		{
			var rootSection = new RootSectionModel();
			var vegaSection = new VegaSectionModel();

			rootSection
				.GetType()
				.GetProperty(nameof(RootSectionModel.Vega))
				.SetValue(rootSection, vegaSection);

			vegaSection
				.GetType()
				.GetProperty(nameof(VegaSectionModel.HostName))
				.SetValue(vegaSection, vegaHostName);

			starsConfigurationServiceMock
				.Setup(service => service.Root)
				.Returns(rootSection);
		}

		private void SetupHttpServiceMock(bool isHttpRequestSuccessful = true)
		{
			var httpResponseModel = new HttpResponseWithBodyModel<UserAreCredentialsValidResponseDto>
			{
				IsSuccessful = isHttpRequestSuccessful
			};

			if (isHttpRequestSuccessful)
			{
				httpResponseModel.Body = new UserAreCredentialsValidResponseDto
				{
					AreUserCredentialsValid = AreUserCredentialsValid
				};
			}

			httpServiceMock
				.Setup(service => service.SendRequestAsync<UserAreCredentialsValidResponseDto>(
					It.IsAny<HttpRequestModel>()))
				.Returns(Task.FromResult(httpResponseModel));
		}
	}
}
