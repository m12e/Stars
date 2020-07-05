using System;
using Vega.Core.Enums;

namespace Vega.Api.Dto.UserAccount
{
	/// <summary>
	/// DTO с данными об учётной записи пользователя
	/// </summary>
	public class UserAccountDto
	{
		/// <summary>
		/// Идентификатор записи в базе данных
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Логин
		/// </summary>
		public string Login { get; set; }

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
