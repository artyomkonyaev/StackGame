using System;
using System.Collections.Generic;
using System.Linq;

namespace StackGame
{
    /// <summary>
    /// Расширения
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Перемешать
        /// </summary>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
		{
			Random rnd = new Random();
			return source.OrderBy(item => rnd.Next());
		}
    }
}
