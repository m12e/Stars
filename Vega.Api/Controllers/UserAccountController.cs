using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stars.Api.Dto.Common;
using System;
using System.Threading.Tasks;
using Vega.Api.Dto.UserAccount;
using Vega.Core.DataServices.Interfaces;
using Vega.Core.Models;

namespace Vega.Api.Controllers
{
	/// <summary>
	/// Контроллер для операций с учётными записями пользователей
	/// </summary>
	[ApiController]
	[Route("api/userAccount")]
	public class UserAccountController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IUserAccountDataService _userAccountDataService;

		public UserAccountController(
			IMapper mapper,
			IUserAccountDataService userAccountDataService)
		{
			_mapper = mapper;
			_userAccountDataService = userAccountDataService;
		}

		/// <summary>
		/// Получить учётную запись пользователя по идентификатору
		/// </summary>
		[HttpGet("getById")]
		public async Task<UserAccountDto> GetByIdAsync(int userAccountId)
		{
			var model = await _userAccountDataService.GetByIdAsync(userAccountId);
			var dto = _mapper.Map<UserAccountDto>(model);

			return dto;
		}

		/// <summary>
		/// Получить учётную запись пользователя по GUID
		/// </summary>
		[HttpGet("getByGuid")]
		public async Task<UserAccountDto> GetByGuidAsync(Guid userAccountGuid)
		{
			var model = await _userAccountDataService.GetByGuidAsync(userAccountGuid);
			var dto = _mapper.Map<UserAccountDto>(model);

			return dto;
		}

		/// <summary>
		/// Получить список всех учётных записей пользователей
		/// </summary>
		[HttpGet("getAll")]
		public async Task<UserAccountDto[]> GetAllAsync()
		{
			var modelList = await _userAccountDataService.GetAllAsync();
			var dtoList = _mapper.Map<UserAccountDto[]>(modelList);

			return dtoList;
		}

		/// <summary>
		/// Создать учётную запись пользователя
		/// </summary>
		[HttpPost("create")]
		public async Task<UserAccountGuidDto> CreateAsync(UserAccountForCreateDto dto)
		{
			var model = _mapper.Map<UserAccountForCreateModel>(dto);
			var userAccountGuid = await _userAccountDataService.CreateAsync(model);

			return new UserAccountGuidDto
			{
				UserAccountGuid = userAccountGuid
			};
		}

		/// <summary>
		/// Изменить статус учётной записи пользователя
		/// </summary>
		[HttpPost("changeStatus")]
		public async Task<SuccessMessageDto> ChangeStatusAsync(UserAccountForChangeStatusDto dto)
		{
			await _userAccountDataService.ChangeStatusAsync(dto.Guid, dto.NewStatus);

			return new SuccessMessageDto();
		}

		/// <summary>
		/// Проверить, существует ли учётная запись пользователя
		/// </summary>
		[HttpPost("isExisting")]
		public async Task<UserAccountIsExistingResponseDto> IsExistingAsync(UserAccountIsExistingRequestDto dto)
		{
			var isUserAccountExisting = await _userAccountDataService.IsExistingAsync(dto.Login);

			return new UserAccountIsExistingResponseDto
			{
				IsUserAccountExisting = isUserAccountExisting
			};
		}

		/// <summary>
		/// Проверить, валидны ли параметры учётной записи пользователя
		/// </summary>
		[HttpPost("areValid")]
		public async Task<UserAccountAreParametersValidResponseDto> AreValidAsync(UserAccountAreParametersValidRequestDto dto)
		{
			var areUserAccountParametersValid = await _userAccountDataService.AreValidAsync(dto.Login, dto.PasswordHashBase64);

			return new UserAccountAreParametersValidResponseDto
			{
				AreUserAccountParametersValid = areUserAccountParametersValid
			};
		}
	}
}
