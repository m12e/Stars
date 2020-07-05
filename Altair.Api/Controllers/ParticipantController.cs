using Altair.Api.Dto.Participant;
using Altair.Core.DataServices.Interfaces;
using Altair.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stars.Api.Constants;
using Stars.Api.Dto.Common;
using System.Threading.Tasks;

namespace Altair.Api.Controllers
{
	/// <summary>
	/// Контроллер для операций с участниками
	/// </summary>
	[Authorize(AuthenticationSchemes = AuthenticationSchemeConstants.BASIC)]
	[ApiController]
	[Route("api/participant")]
	public class ParticipantController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IParticipantDataService _participantDataService;

		public ParticipantController(
			IMapper mapper,
			IParticipantDataService participantDataService)
		{
			_mapper = mapper;
			_participantDataService = participantDataService;
		}

		/// <summary>
		/// Получить общее количество участников
		/// </summary>
		[AllowAnonymous]
		[HttpGet("getCount")]
		public async Task<ParticipantCountDto> GetCountAsync()
		{
			var modelCount = await _participantDataService.GetCountAsync();
			
			return new ParticipantCountDto
			{
				ParticipantCount = modelCount
			};
		}

		/// <summary>
		/// Получить участника по идентификатору
		/// </summary>
		[AllowAnonymous]
		[HttpGet("getById")]
		public async Task<ParticipantDto> GetByIdAsync(int participantId)
		{
			var model = await _participantDataService.GetByIdAsync(participantId);
			var dto = _mapper.Map<ParticipantDto>(model);

			return dto;
		}

		/// <summary>
		/// Получить список всех участников
		/// </summary>
		[AllowAnonymous]
		[HttpGet("getAll")]
		public async Task<ParticipantDto[]> GetAllAsync()
		{
			var modelList = await _participantDataService.GetAllAsync();
			var dtoList = _mapper.Map<ParticipantDto[]>(modelList);

			return dtoList;
		}

		/// <summary>
		/// Получить краткие описания всех участников
		/// </summary>
		[AllowAnonymous]
		[HttpGet("getAllSummaries")]
		public async Task<ParticipantSummaryDto[]> GetAllSummariesAsync()
		{
			var modelList = await _participantDataService.GetAllAsync();
			var dtoList = _mapper.Map<ParticipantSummaryDto[]>(modelList);

			return dtoList;
		}

		/// <summary>
		/// Сохранить участника
		/// </summary>
		[HttpPost("save")]
		public async Task<RecordIdDto> SaveAsync(ParticipantBaseDto dto)
		{
			var model = _mapper.Map<ParticipantModel>(dto);
			var recordId = await _participantDataService.SaveAsync(model);

			return new RecordIdDto
			{
				RecordId = recordId
			};
		}

		/// <summary>
		/// Сохранить участников из переданного списка
		/// </summary>
		[HttpPost("saveList")]
		public async Task<RecordCountDto> SaveListAsync(ParticipantBaseDto[] dtoList)
		{
			var modelList = _mapper.Map<ParticipantModel[]>(dtoList);
			var recordCount = await _participantDataService.SaveListAsync(modelList);

			return new RecordCountDto
			{
				RecordCount = recordCount
			};
		}

		/// <summary>
		/// Обновить данные участника
		/// </summary>
		[HttpPost("update")]
		public async Task<SuccessMessageDto> UpdateAsync(ParticipantDto dto)
		{
			var model = _mapper.Map<ParticipantModel>(dto);
			await _participantDataService.UpdateAsync(model);

			return new SuccessMessageDto();
		}

		/// <summary>
		/// Удалить участника по идентификатору
		/// </summary>
		[HttpDelete("deleteById")]
		public async Task<SuccessMessageDto> DeleteByIdAsync(int participantId)
		{
			await _participantDataService.DeleteByIdAsync(participantId);

			return new SuccessMessageDto();
		}
	}
}
