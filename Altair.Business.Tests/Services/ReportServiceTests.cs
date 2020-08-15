using Altair.Business.Tests.Services.Fixtures;
using Moq;
using Stars.Business.Enums;
using Stars.Business.MessageModels;
using System.Threading.Tasks;
using Xunit;

namespace Altair.Business.Tests.Services
{
	public class ReportServiceTests : ReportServiceFixture
	{
		[Fact]
		public async Task TestSendAsync()
		{
			var reportService = GetReportService();

			await reportService.SendAsync();

			rabbitPublicationServiceMock.Verify(
				service => service.PublishMessage(
					InterserviceQueueTypeEnum.Deneb,
					It.Is<ParticipantReportMessageModel>(model => model.ParticipantCount == PARTICIPANT_COUNT)),
				Times.Once);
		}
	}
}