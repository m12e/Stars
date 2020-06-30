using Altair.Api.Dto;
using Altair.Core.DataServices.Interfaces;
using Altair.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Altair.Api.Controllers
{
	[ApiController]
	[Route("api/participant")]
	public class ParticipantController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IParticipantDataService _participantService;

		public ParticipantController(
			IMapper mapper,
			IParticipantDataService participantService)
		{
			_mapper = mapper;
			_participantService = participantService;
		}

		/// <summary>
		/// Получить список всех участников
		/// </summary>
		[HttpGet("getAll")]
		public async Task<ParticipantDto[]> GetAllAsync()
		{
			var modelList = await _participantService.GetAllAsync();
			var dtoList = _mapper.Map<ParticipantDto[]>(modelList);

			return dtoList;
		}

		/// <summary>
		/// Получить краткие описания всех участников
		/// </summary>
		[HttpGet("getAllSummaries")]
		public async Task<ParticipantSummaryDto[]> GetAllSummariesAsync()
		{
			var modelList = await _participantService.GetAllAsync();
			var dtoList = _mapper.Map<ParticipantSummaryDto[]>(modelList);

			return dtoList;
		}

		/// <summary>
		/// Сохранить участника
		/// </summary>
		/// <returns>Идентификатор созданной записи</returns>
		[HttpPost("save")]
		public async Task<int> SaveAsync(ParticipantBaseDto dto)
		{
			var model = _mapper.Map<ParticipantModel>(dto);
			var recordId = await _participantService.SaveAsync(model);

			return recordId;
		}
	}
}
