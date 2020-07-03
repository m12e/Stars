using Altair.Business.Services.Interfaces;
using Altair.Core.DataServices.Interfaces;
using Stars.Business.Enums;
using Stars.Business.MessageModels;
using Stars.Business.Services.Interfaces;
using Stars.Core.Logger.Interfaces;
using System.Threading.Tasks;

namespace Altair.Business.Services
{
	public class ReportService : IReportService
	{
		private readonly IStarsLogger _logger;
		private readonly IParticipantDataService _participantService;
		private readonly IRabbitPublicationService _rabbitPublicationService;

		public ReportService(
			IStarsLogger logger,
			IParticipantDataService participantService,
			IRabbitPublicationService rabbitPublicationService)
		{
			_logger = logger;
			_participantService = participantService;
			_rabbitPublicationService = rabbitPublicationService;
		}

		public async Task SendAsync()
		{
			_logger.Debug("Sending report...");

			var participantCount = await _participantService.GetCountAsync();
			var messageModel = new ParticipantReportMessageModel
			{
				ParticipantCount = participantCount
			};

			_rabbitPublicationService.PublishMessage(InterserviceQueueTypeEnum.Deneb, messageModel);

			_logger.Information("Report was sucessfully sent...");
		}
	}
}
