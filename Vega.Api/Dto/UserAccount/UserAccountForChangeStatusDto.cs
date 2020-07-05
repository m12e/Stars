using System;
using Vega.Core.Enums;

namespace Vega.Api.Dto.UserAccount
{
	/// <summary>
	/// DTO для изменения статуса учётной записи пользователя
	/// </summary>
	public class UserAccountForChangeStatusDto
	{
		/// <summary>
		/// GUID учётной записи
		/// </summary>
		public Guid Guid { get; set; }

		/// <summary>
		/// Новый статус учётной записи
		/// </summary>
		public UserAccountStatusEnum NewStatus { get; set; }
	}
}
