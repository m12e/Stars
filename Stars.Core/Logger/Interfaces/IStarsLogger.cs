namespace Stars.Core.Logger.Interfaces
{
	/// <summary>
	/// Логгер для проектов Stars
	/// </summary>
	public interface IStarsLogger
	{
		/// <summary>
		/// Сохранить в лог сообщение с подробными деталями или конфиденциальными данными
		/// </summary>
		void Trace(string message);

		/// <summary>
		/// Сохранить в лог сообщение для отладки
		/// </summary>
		void Debug(string message);

		/// <summary>
		/// Сохранить в лог информационное сообщение
		/// </summary>
		void Information(string message);

		/// <summary>
		/// Сохранить в лог сообщение с предупреждением
		/// </summary>
		void Warning(string message);

		/// <summary>
		/// Сохранить в лог сообщение с ошибкой
		/// </summary>
		void Error(string message);

		/// <summary>
		/// Сохранить в лог сообщение с критической ошибкой
		/// </summary>
		void Critical(string message);
	}
}
