using System.Collections.Generic;
using StackGame.Units;

namespace StackGame.Army
{
    /// <summary>
    /// Интерфейс армии
    /// </summary>
    public interface IArmy
    {
		#region Свойства

        /// <summary>
        /// Единицы армии
        /// </summary>
        List<IUnit> Units { get; }

		#endregion

		#region Методы

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
		string ToString();

		#endregion
	}
}
