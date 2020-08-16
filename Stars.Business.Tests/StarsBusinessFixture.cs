using AutoFixture;

namespace Stars.Business.Tests
{
	public abstract class StarsBusinessFixture
	{
		protected StarsBusinessFixture()
		{
			AutoFixture = new Fixture();
		}

		public Fixture AutoFixture { get; }

		/// <summary>
		/// Валидны ли учётные данные пользователя
		/// </summary>
		public bool AreUserCredentialsValid = true;
	}
}
