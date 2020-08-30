using System;

namespace Vega.Api.Dto.UserAccount
{
	/// <summary>
	/// DTO с GUID учётной записи пользователя
	/// </summary>
	public class UserAccountGuidDto
	{
		/// <summary>
		/// GUID учётной записи
		/// </summary>
		public Guid UserAccountGuid { get; set; }
	}
}
