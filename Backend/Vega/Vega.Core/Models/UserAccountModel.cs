using System;
using Vega.Core.Enums;

namespace Vega.Core.Models
{
	/// <summary>
	/// Учётная запись пользователя
	/// </summary>
	public class UserAccountModel : UserAccountBaseModel
	{
		/// <summary>
		/// Идентификатор записи в базе данных
		/// </summary>
		public int Id { get; set; }

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
