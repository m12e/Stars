using AutoMapper;
using Deneb.Core.DataServices.Interfaces;
using Deneb.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Stars.Business.Enums;
using Stars.Business.MessageModels;
using Stars.Mq.MessageConsumers;
using System;
using System.Threading.Tasks;

namespace Deneb.Mq.MessageConsumers
{
	/// <summary>
	/// Подписчик на сообщения с отчётами об участниках
	/// </summary>
	public class ParticipantReportMessageConsumer : InterserviceMessageConsumer<ParticipantReportMessageModel>
	{
		private readonly IMapper _mapper;
		private readonly IServiceProvider _serviceProvider;

		public ParticipantReportMessageConsumer(
			IMapper mapper,
			IServiceProvider serviceProvider)
		{
			_mapper = mapper;
			_serviceProvider = serviceProvider;
		}

		public override InterserviceMessageTypeEnum MessageType => InterserviceMessageTypeEnum.ParticipantReport;

		protected async override Task ConsumeAsync(ParticipantReportMessageModel messageModel)
		{
			var reportForSaveModel = _mapper.Map<ReportForSaveModel>(messageModel);

			using var serviceScope = _serviceProvider.CreateScope();
			var reportDataService = serviceScope.ServiceProvider.GetService<IReportDataService>();

			await reportDataService.SaveAsync(reportForSaveModel);
		}
	}
}
