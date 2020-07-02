﻿using AutoMapper;
using Deneb.Core.DataServices.Interfaces;
using Deneb.Core.Models;
using Deneb.Dal.DomainModels;
using Microsoft.EntityFrameworkCore;
using Stars.Core.Logger.Interfaces;
using Stars.Dal.EntityFramework.Repositories.Interfaces;
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
			_logger.Debug("Getting all reports ordered by date of creation...");

			var reports = await _repository.GetNoTrackingQuery()
				.OrderBy(report => report.DateOfCreationUtc)
				.ToArrayAsync();

			var reportModels = _mapper.Map<ReportModel[]>(reports);

			_logger.Information($"All reports were successfully loaded (count = {reportModels.Length})");

			return reportModels;
		}
	}
}
