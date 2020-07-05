using Stars.Business.Models.User;
using System.Threading.Tasks;

namespace Stars.Business.Services.Interfaces
{
	/// <summary>
	/// Сервис для операций, связанных с пользователями и их аутентификацией 
	/// </summary>
	public interface IUserIdentityService
	{
		/// <summary>
		/// Проверить, валидны ли указанные параметры аутентификации пользователя
		/// </summary>
		Task<bool> IsUserIdentityValidAsync(UserIdentityModel userIdentityModel);
	}
}
