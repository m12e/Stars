using Altair.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Stars.Api.Dto.Common;
using System.Threading.Tasks;

namespace Altair.Api.Controllers
{
	/// <summary>
	/// Контроллер для операций с отчётами
	/// </summary>
	[ApiController]
	[Route("api/report")]
	public class ReportController : ControllerBase
	{
		private readonly IReportService _reportService;

		public ReportController(IReportService reportService)
		{
			_reportService = reportService;
		}

		/// <summary>
		/// Отправить отчёт
		/// </summary>
		[HttpGet("send")]
		public async Task<SuccessMessageDto> SendAsync()
		{
			await _reportService.SendAsync();

			return new SuccessMessageDto();
		}
	}
}
