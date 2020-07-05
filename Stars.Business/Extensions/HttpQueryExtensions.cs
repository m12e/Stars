using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;

namespace Stars.Business.Extensions
{
	/// <summary>
	/// Методы расширения для операций со строками HTTP-запроса
	/// </summary>
	public static class HttpQueryExtensions
	{
		/// <summary>
		/// Добавить к исходной строке HTTP-запроса указанный путь
		/// </summary>
		public static string AddQueryPath(this string query, string path)
		{
			return query.TrimEnd('/') + '/' + path.TrimStart('/');
		}

		/// <summary>
		/// Добавить к исходной строке HTTP-запроса указанный параметр
		/// </summary>
		public static string AddQueryParameter(this string query, string parameterName, string parameterValue)
		{
			return QueryHelpers.AddQueryString(query, parameterName, parameterValue);
		}

		/// <summary>
		/// Добавить к исходной строке HTTP-запроса указанные параметры
		/// </summary>
		public static string AddQueryParameters(this string query, Dictionary<string, string> parameters)
		{
			return QueryHelpers.AddQueryString(query, parameters);
		}
	}
}
