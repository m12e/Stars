﻿namespace Stars.Business.Enums
{
	/// <summary>
	/// Тип очереди при внутренней коммуникации между приложениями
	/// </summary>
	public enum InterserviceQueueTypeEnum : byte
	{
		/// <summary>
		/// Альтаир
		/// </summary>
		Altair = 1,

		/// <summary>
		/// Денеб
		/// </summary>
		Deneb = 2
	}
}
