using System.Security.Cryptography;
using System.Text;

namespace Stars.Core.Extensions
{
	/// <summary>
	/// Методы расширения для вычисления хеша
	/// </summary>
	public static class HashExtensions
	{
		/// <summary>
		/// Вычислить MD5-хеш строки
		/// </summary>
		public static byte[] GetMD5(this string textValue)
		{
			return textValue.GetHash(HashAlgorithmName.MD5);
		}

		/// <summary>
		/// Вычислить SHA256-хеш строки
		/// </summary>
		public static byte[] GetSHA256(this string textValue)
		{
			return textValue.GetHash(HashAlgorithmName.SHA256);
		}

		/// <summary>
		/// Вычислить SHA512-хеш строки
		/// </summary>
		public static byte[] GetSHA512(this string textValue)
		{
			return textValue.GetHash(HashAlgorithmName.SHA512);
		}

		/// <summary>
		/// Вычислить хеш строки по указанному алгоритму
		/// </summary>
		private static byte[] GetHash(this string textValue, HashAlgorithmName hashAlgorithmName)
		{
			var textBytes = Encoding.UTF8.GetBytes(textValue);
			var hashBytes = textBytes.GetHash(hashAlgorithmName);

			return hashBytes;
		}

		/// <summary>
		/// Вычислить хеш массива байтов по указанному алгоритму
		/// </summary>
		private static byte[] GetHash(this byte[] bytes, HashAlgorithmName hashAlgorithmName)
		{
			using var hashAlgorithm = HashAlgorithm.Create(hashAlgorithmName.Name);
			var hashBytes = hashAlgorithm.ComputeHash(bytes);

			return hashBytes;
		}
	}
}
