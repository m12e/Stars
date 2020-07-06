using Stars.Business.Models.User;
using System.Threading.Tasks;

namespace Stars.Business.Services.Interfaces
{
	/// <summary>
	/// Сервис для операций, связанных с пользователями
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Проверить, валидны ли указанные учётные данные пользователя
		/// </summary>
		Task<bool> AreCredentialsValidAsync(UserCredentialsModel userCredentialsModel);
	}
}
