using AutoMapper;
using Deneb.Core.DataServices.Interfaces;
using Deneb.Core.Models;
using Deneb.Dal.DomainModels;
using Microsoft.EntityFrameworkCore;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using Stars.Dal.EntityFramework.Repositories.Interfaces;
using Stars.Dal.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Deneb.Dal.DataServices
{
	public class ReportDataService : IReportDataService
	{
		private readonly IStarsLogger _logger;
		private readonly IMapper _mapper;
		private readonly IQueryableDomainRepository<ReportDomainModel> _repository;

		public ReportDataService(
			IStarsLogger logger,
			IMapper mapper,
			IQueryableDomainRepository<ReportDomainModel> repository)
		{
			_logger = logger;
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<ReportModel[]> GetAllOrderedAsync()
		{
			_logger.Information("Getting all reports ordered by date of creation...");

			var reports = await _repository.GetNoTrackingQuery()
				.OrderBy(report => report.DateOfCreationUtc)
				.ForEachOfQueryable(report =>
				{
					report.DateOfCreationUtc = DateTime.SpecifyKind(report.DateOfCreationUtc, DateTimeKind.Utc);
				})
				.ToArrayAsync();

			var reportModels = _mapper.Map<ReportModel[]>(reports);

			_logger.Information($"All reports were successfully loaded (count = {reportModels.Length})");

			return reportModels;
		}

		public async Task<int> SaveAsync(ReportForSaveModel reportForSaveModel)
		{
			_logger.Information($"Saving report ({reportForSaveModel.ToJson()})...");

			var report = new ReportDomainModel
			{
				ParticipantCount = reportForSaveModel.ParticipantCount,
				DateOfCreationUtc = DateTime.UtcNow
			};

			var wasRecordSaved = await _repository.SaveAsync(report);
			if (!wasRecordSaved)
			{
				throw new DomainModelOperationException($"Error while saving report");
			}

			_logger.Information($"Report was successfully saved ({report.ToJson()})");

			return report.Id;
		}
	}
}
