using AutoMapper;
using Deneb.Api.Dto.Report;
using Deneb.Core.DataServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Deneb.Api.Controllers
{
	/// <summary>
	/// Контроллер для операций с отчётами
	/// </summary>
	[ApiController]
	[Route("api/report")]
	public class ReportController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IReportDataService _reportDataService;

		public ReportController(
			IMapper mapper,
			IReportDataService reportDataService)
		{
			_mapper = mapper;
			_reportDataService = reportDataService;
		}

		/// <summary>
		/// Получить список всех отчётов, упорядоченный по дате создания
		/// </summary>
		[HttpGet("getAllOrdered")]
		public async Task<ReportDto[]> GetAllOrderedAsync()
		{
			var modelList = await _reportDataService.GetAllOrderedAsync();
			var dtoList = _mapper.Map<ReportDto[]>(modelList);

			return dtoList;
		}
	}
}
