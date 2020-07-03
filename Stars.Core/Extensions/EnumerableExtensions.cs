using System;
using System.Collections.Generic;
using System.Linq;

namespace Stars.Core.Extensions
{
	/// <summary>
	/// Методы расширения для операций с перечислениями
	/// </summary>
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Выполнить действие для каждого элемента перечисления
		/// </summary>
		public static IEnumerable<T> ForEachOfEnumerable<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var element in enumerable)
			{
				action(element);
			}

			return enumerable;
		}

		/// <summary>
		/// Выполнить действие для каждого элемента запроса
		/// </summary>
		public static IQueryable<T> ForEachOfQueryable<T>(this IQueryable<T> queryable, Action<T> action)
		{
			foreach (var element in queryable)
			{
				action(element);
			}

			return queryable;
		}
	}
}
