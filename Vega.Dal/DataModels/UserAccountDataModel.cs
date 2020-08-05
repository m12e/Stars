using Stars.Dal.DataModels;
using System;
using Vega.Core.Enums;

namespace Vega.Dal.DataModels
{
	/// <summary>
	/// Учётная запись пользователя
	/// </summary>
	public class UserAccountDataModel : BaseDataModel
	{
		/// <summary>
		/// Логин
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// Хеш пароля в формате Base64
		/// </summary>
		public string PasswordHash { get; set; }

		/// <summary>
		/// GUID учётной записи
		/// </summary>
		public Guid Guid { get; set; }

		/// <summary>
		/// Статус учётной записи
		/// </summary>
		public UserAccountStatusEnum Status { get; set; }

		/// <summary>
		/// Дата и время создания учётной записи (UTC)
		/// </summary>
		public DateTime DateOfCreationUtc { get; set; }

		/// <summary>
		/// Дата и время последнего изменения учётной записи (UTC)
		/// </summary>
		public DateTime DateOfLastChangeUtc { get; set; }
	}
}
