using System;
using System.Threading.Tasks;
using Vega.Core.Enums;
using Vega.Core.Models;

namespace Vega.Core.DataServices.Interfaces
{
	/// <summary>
	/// Сервис для операций с учётными записями пользователей
	/// </summary>
	public interface IUserAccountDataService
	{
		/// <summary>
		/// Получить учётную запись пользователя по идентификатору
		/// </summary>
		Task<UserAccountModel> GetByIdAsync(int userAccountId);

		/// <summary>
		/// Получить учётную запись пользователя по GUID
		/// </summary>
		Task<UserAccountModel> GetByGuidAsync(Guid userAccountGuid);

		/// <summary>
		/// Получить список всех учётных записей пользователей
		/// </summary>
		Task<UserAccountModel[]> GetAllAsync();

		/// <summary>
		/// Создать учётную запись пользователя
		/// </summary>
		/// <returns>GUID созданной учётной записи</returns>
		Task<Guid> CreateAsync(UserAccountForCreateModel userAccountForCreateModel);

		/// <summary>
		/// Изменить статус учётной записи пользователя
		/// </summary>
		Task ChangeStatusAsync(Guid userAccountGuid, UserAccountStatusEnum newStatus);

		/// <summary>
		/// Проверить, существует ли учётная запись пользователя с указанным логином
		/// </summary>
		Task<bool> IsExistingAsync(string userAccountLogin);

		/// <summary>
		/// Проверить, валидны ли указанные логин и хеш пароля для учётной записи пользователя
		/// </summary>
		/// <param name="userAccountLogin">Логин</param>
		/// <param name="userAccountPasswordHash">Хеш пароля в формате Base64</param>
		Task<bool> AreValidAsync(string userAccountLogin, string userAccountPasswordHash);
	}
}
