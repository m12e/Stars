using System;

namespace Stars.Core.Extensions
{
	/// <summary>
	/// Методы расширения для операций, связанных с Enum'ами
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Преобразовать текстовое значение в Enum
		/// </summary>
		public static TEnum ToEnum<TEnum>(this string textValue)
			where TEnum : struct
		{
			if (!Enum.TryParse<TEnum>(textValue, true, out var enumValue))
			{
				throw new ArgumentException($"Text value '{textValue}' is not valid for enum '{typeof(TEnum)}'");
			}

			return enumValue;
		}
	}
}
