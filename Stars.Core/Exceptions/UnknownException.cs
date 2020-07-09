namespace Stars.Core.Exceptions
{
	/// <summary>
	/// Исключение, причины которого неизвестны
	/// </summary>
	public sealed class UnknownException : StarsException
	{
		/// <summary>
		/// Сообщение о неизвестной ошибке
		/// </summary>
		public const string UNKNOWN_ERROR_MESSAGE = "Unknown error";

		public UnknownException()
			: base(UNKNOWN_ERROR_MESSAGE)
		{
		}
	}
}
