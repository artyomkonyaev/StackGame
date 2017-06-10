using System.Collections.Generic;
using System.Linq;

namespace StackGame
{
    /// <summary>
    /// Расширения
    /// </summary>
    public static class Extensions
    {
		#region Методы

		/// <summary>
		/// Пустая ли коллекция
		/// </summary>
		public static bool IsEmpty<T>(this IEnumerable<T> source)
		{
			var isEmpty = !source.Any();
			return isEmpty;
		}

		/// <summary>
		/// Перемешать
		/// </summary>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(item => Helpers.Random.Next());
        }

        #endregion
    }
}
