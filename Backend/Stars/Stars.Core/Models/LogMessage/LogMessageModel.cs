using System;

namespace Stars.Core.Models.LogMessage
{
	/// <summary>
	/// Сообщение для логирования
	/// </summary>
	public class LogMessageModel
	{
		/// <summary>
		/// Текст сообщения
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Уровень логирования
		/// </summary>
		public string LogLevel { get; set; }

		/// <summary>
		/// Дата и время логирования
		/// </summary>
		public DateTimeOffset TimeStamp { get; set; }

		/// <summary>
		/// Идентификатор потока
		/// </summary>
		public int? ThreadId { get; set; }
	}
}
