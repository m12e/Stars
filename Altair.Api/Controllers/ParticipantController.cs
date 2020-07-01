using Altair.Api.Dto;
using Altair.Core.DataServices.Interfaces;
using Altair.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Altair.Api.Controllers
{
	/// <summary>
	/// Контроллер для операций с участниками
	/// </summary>
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
		/// Получить участника по идентификатору
		/// </summary>
		[HttpGet("getById")]
		public async Task<ParticipantDto> GetByIdAsync(int participantId)
		{
			var model = await _participantService.GetByIdAsync(participantId);
			var dto = _mapper.Map<ParticipantDto>(model);

			return dto;
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

		/// <summary>
		/// Сохранить участников из переданного списка
		/// </summary>
		/// <returns>Количество созданных записей</returns>
		[HttpPost("saveList")]
		public async Task<int> SaveListAsync(ParticipantBaseDto[] dtoList)
		{
			var modelList = _mapper.Map<ParticipantModel[]>(dtoList);
			var recordCount = await _participantService.SaveListAsync(modelList);

			return recordCount;
		}

		/// <summary>
		/// Удалить участника по идентификатору
		/// </summary>
		[HttpDelete("deleteById")]
		public async Task DeleteByIdAsync(int participantId)
		{
			await _participantService.DeleteByIdAsync(participantId);
		}
	}
}
