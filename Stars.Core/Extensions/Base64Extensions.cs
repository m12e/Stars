using System;
using System.Text;

namespace Stars.Core.Extensions
{
	/// <summary>
	/// Методы расширения для операций, связанных с Base64
	/// </summary>
	public static class Base64Extensions
	{
		/// <summary>
		/// Кодировать массив байтов в строку Base64
		/// </summary>
		/// <remarks>Кодирование будет выполнено без вставки переводов строк</remarks>
		public static string ToBase64(this byte[] bytes)
		{
			return bytes.ToBase64(Base64FormattingOptions.None);
		}

		/// <summary>
		/// Кодировать массив байтов в строку Base64 с заданными опциями
		/// </summary>
		public static string ToBase64(this byte[] bytes, Base64FormattingOptions options)
		{
			return Convert.ToBase64String(bytes, options);
		}

		/// <summary>
		/// Декодировать строку Base64 в массив байтов
		/// </summary>
		public static byte[] FromBase64ToBytes(this string base64Value)
		{
			return Convert.FromBase64String(base64Value);
		}

		/// <summary>
		/// Декодировать строку Base64 в текст
		/// </summary>
		public static string FromBase64ToString(this string base64Value)
		{
			var decodedTextBytes = base64Value.FromBase64ToBytes();
			var decodedText = Encoding.UTF8.GetString(decodedTextBytes);

			return decodedText;
		}
	}
}
