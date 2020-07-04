using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stars.Core.Extensions;
using Stars.Core.Logger.Interfaces;
using Stars.Dal.EntityFramework.Repositories.Interfaces;
using Stars.Dal.Exceptions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Vega.Core.DataServices.Interfaces;
using Vega.Core.Enums;
using Vega.Core.Exceptions;
using Vega.Core.Models;
using Vega.Dal.DomainModels;

namespace Vega.Dal.DataServices
{
	public class UserAccountDataService : IUserAccountDataService
	{
		private readonly IStarsLogger _logger;
		private readonly IMapper _mapper;
		private readonly IQueryableDomainRepository<UserAccountDomainModel> _repository;

		public UserAccountDataService(
			IStarsLogger logger,
			IMapper mapper,
			IQueryableDomainRepository<UserAccountDomainModel> repository)
		{
			_logger = logger;
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<UserAccountModel> GetByIdAsync(int userAccountId)
		{
			_logger.Debug($"Getting user account with id = {userAccountId}...");

			var userAccount = await _repository.GetByIdAsync(userAccountId);
			if (userAccount == null)
			{
				throw new DomainModelNotFoundException($"User account with id = {userAccountId} was not found");
			}

			ConvertDateTimeValuesToUtc(userAccount);
			var userAccountModel = _mapper.Map<UserAccountModel>(userAccount);

			_logger.Information($"User account with id = {userAccountId} was successfully loaded");

			return userAccountModel;
		}

		public async Task<UserAccountModel> GetByGuidAsync(Guid userAccountGuid)
		{
			var userAccount = await GetByGuidCoreAsync(userAccountGuid, false);
			var userAccountModel = _mapper.Map<UserAccountModel>(userAccount);

			_logger.Information($"User account with guid '{userAccountGuid}' was successfully loaded");

			return userAccountModel;
		}

		public async Task<UserAccountModel[]> GetAllAsync()
		{
			_logger.Debug("Getting all user accounts...");

			var userAccounts = await _repository.GetAllAsync();

			userAccounts.ForEachOfEnumerable(userAccount => ConvertDateTimeValuesToUtc(userAccount));
			var userAccountModels = _mapper.Map<UserAccountModel[]>(userAccounts);

			_logger.Information($"All user accounts were successfully loaded (count = {userAccountModels.Length})");

			return userAccountModels;
		}

		public async Task<Guid> CreateAsync(UserAccountForCreateModel userAccountForCreateModel)
		{
			_logger.Debug($"Creating user account with login '{userAccountForCreateModel.Login}'...");

			var currentDateTime = DateTime.UtcNow;

			var userAccount = new UserAccountDomainModel
			{
				Login = userAccountForCreateModel.Login,
				PasswordHash = userAccountForCreateModel.Password.GetSHA256().ToBase64(),
				Guid = Guid.NewGuid(),
				Status = UserAccountStatusEnum.Active,
				DateOfCreationUtc = currentDateTime,
				DateOfLastChangeUtc = currentDateTime
			};

			var wasRecordSaved = await _repository.SaveAsync(userAccount);
			if (!wasRecordSaved)
			{
				throw new DomainModelOperationException($"Error while creating user account");
			}

			_logger.Information($"User account was successfully created ({userAccount.ToJson()})");

			return userAccount.Guid;
		}

		public async Task ChangeStatusAsync(Guid userAccountGuid, UserAccountStatusEnum newStatus)
		{
			_logger.Debug($"Changing status of user account with guid '{userAccountGuid}' to '{newStatus}'...");

			var userAccount = await GetByGuidCoreAsync(userAccountGuid, true);
			if (userAccount.Status == newStatus)
			{
				throw new UserAccountException($"User account with guid '{userAccountGuid}' already has status '{newStatus}'");
			}

			var oldStatus = userAccount.Status;
			userAccount.Status = newStatus;

			var recordCount = await _repository.SaveContextChangesAsync();
			if (recordCount == 0)
			{
				throw new DomainModelOperationException($"Error while changing status of user account");
			}

			_logger.Information(
				$"Status of user account with guid '{userAccountGuid}' " +
				$"was successfully changed from '{oldStatus}' to '{newStatus}'...");
		}

		public async Task<bool> IsExistingAsync(string userAccountLogin)
		{
			var userAccountLogText = $"user account with login '{userAccountLogin}'";

			_logger.Debug($"Checking if {userAccountLogText} exists...");

			var isExisting = await _repository.GetNoTrackingQuery()
				.AnyAsync(account => account.Login == userAccountLogin);

			if (isExisting)
			{
				_logger.Information($"Done, {userAccountLogText} exists");
			}
			else
			{
				_logger.Information($"Done, {userAccountLogText} does not exist");
			}

			return isExisting;
		}

		public async Task<bool> AreValidAsync(string userAccountLogin, string userAccountPasswordHash)
		{
			var userAccountLogText = $"user account login '{userAccountLogin}' and password hash '{userAccountPasswordHash}'";

			_logger.Debug($"Checking if {userAccountLogText} are valid...");

			var areValid = await _repository.GetNoTrackingQuery()
				.AnyAsync(account =>
					account.Status == UserAccountStatusEnum.Active &&
					account.Login == userAccountLogin &&
					account.PasswordHash == userAccountPasswordHash);

			if (areValid)
			{
				_logger.Information($"Done, {userAccountLogText} are valid");
			}
			else
			{
				_logger.Information($"Done, {userAccountLogText} are not valid");
			}

			return areValid;
		}

		private static void ConvertDateTimeValuesToUtc(UserAccountDomainModel userAccount)
		{
			userAccount.DateOfCreationUtc = DateTime.SpecifyKind(userAccount.DateOfCreationUtc, DateTimeKind.Utc);
			userAccount.DateOfLastChangeUtc = DateTime.SpecifyKind(userAccount.DateOfLastChangeUtc, DateTimeKind.Utc);
		}

		private async Task<UserAccountDomainModel> GetByGuidCoreAsync(Guid userAccountGuid, bool trackQuery)
		{
			_logger.Debug($"Getting user account with guid '{userAccountGuid}' ({nameof(trackQuery)} = {trackQuery})...");

			var userAccount = await _repository.GetQuery(trackQuery)
				.Where(account => account.Guid == userAccountGuid)
				.FirstOrDefaultAsync();

			if (userAccount == null)
			{
				throw new DomainModelNotFoundException($"User account with guid '{userAccountGuid}' was not found");
			}

			ConvertDateTimeValuesToUtc(userAccount);

			return userAccount;
		}
	}
}
