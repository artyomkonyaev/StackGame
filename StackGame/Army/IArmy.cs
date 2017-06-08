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

        /// <summary>
        /// Все ли единицы армии мертвы
        /// </summary>
        bool IsAllDead { get; }

        #endregion

        #region Методы

        /// <summary>
        /// Удалить мертвые единицы армии
        /// </summary>
        void CollectDeadUnits();

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
		string ToString();

		#endregion
	}
}
