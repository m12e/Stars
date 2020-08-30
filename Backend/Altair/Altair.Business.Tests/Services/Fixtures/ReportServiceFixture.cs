using Altair.Business.Services;
using Altair.Core.DataServices.Interfaces;
using Moq;
using Stars.Business.Services.Interfaces;
using Stars.Core.Logger.Interfaces;
using System.Threading.Tasks;

namespace Altair.Business.Tests.Services.Fixtures
{
	public class ReportServiceFixture : AltairBusinessFixture
	{
		public Mock<IStarsLogger> starsLoggerMock = new Mock<IStarsLogger>();
		public Mock<IParticipantDataService> participantDataServiceMock = new Mock<IParticipantDataService>();
		public Mock<IRabbitPublicationService> rabbitPublicationServiceMock = new Mock<IRabbitPublicationService>();

		public ReportService CreateReportService()
		{
			SetupParticipantDataServiceMock();

			return new ReportService(
				starsLoggerMock.Object,
				participantDataServiceMock.Object,
				rabbitPublicationServiceMock.Object);
		}

		private void SetupParticipantDataServiceMock()
		{
			participantDataServiceMock
				.Setup(service => service.GetCountAsync())
				.Returns(Task.FromResult(ParticipantCount));
		}
	}
}