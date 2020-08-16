using Stars.Business.Models.User;

namespace Stars.Business.Tests
{
	public abstract class StarsBusinessFixture
	{
		/// <summary>
		/// Валидны ли учётные данные пользователя
		/// </summary>
		public bool AreUserCredentialsValid = true;

		/// <summary>
		/// Учётные данные пользователя
		/// </summary>
		public UserCredentialsModel UserCredentials => new UserCredentialsModel
		{
			Login = "test_user",
			Password = "123"
		};
	}
}
