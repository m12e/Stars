using Altair.Business.Tests.Services.Fixtures;
using Moq;
using Stars.Business.Enums;
using Stars.Business.MessageModels;
using System.Threading.Tasks;
using Xunit;

namespace Altair.Business.Tests.Services
{
	public class ReportServiceTests : IClassFixture<ReportServiceFixture>
	{
		private readonly ReportServiceFixture _reportServiceFixture;

		public ReportServiceTests(ReportServiceFixture reportServiceFixture)
		{
			_reportServiceFixture = reportServiceFixture;
		}

		[Fact]
		public async Task TestSendAsync()
		{
			var reportService = _reportServiceFixture.GetReportService();

			await reportService.SendAsync();

			_reportServiceFixture.rabbitPublicationServiceMock.Verify(
				service => service.PublishMessage(
					InterserviceQueueTypeEnum.Deneb,
					It.Is<ParticipantReportMessageModel>(model =>
						model.ParticipantCount == _reportServiceFixture.ParticipantCount)),
				Times.Once);
		}
	}
}