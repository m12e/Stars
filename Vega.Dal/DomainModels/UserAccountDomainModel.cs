using Stars.Dal.DomainModels;
using System;
using Vega.Core.Enums;

namespace Vega.Dal.DomainModels
{
	/// <summary>
	/// Учётная запись пользователя
	/// </summary>
	public class UserAccountDomainModel : BaseDomainModel
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
