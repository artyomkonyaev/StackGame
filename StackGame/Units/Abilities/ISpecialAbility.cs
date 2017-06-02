using StackGame.Army;

namespace StackGame.Units.Abilities
{
    /// <summary>
    /// Интерфейс специальных возможностей
    /// </summary>
    public interface ISpecialAbility
    {
		#region Свойства

		/// <summary>
		/// Дальность (измеряется в единицах армии)
		/// </summary>
		int Range { get; }
        /// <summary>
        /// Мощность
        /// </summary>
        int Power { get; }

        #endregion

        #region Методы

        /// <summary>
        /// Применить специальную возможность
        /// </summary>
        void DoSpecialAction(IArmy targetArmy, IUnit targetUnit);

		#endregion
	}
}
