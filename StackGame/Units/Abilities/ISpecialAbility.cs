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
		/// Дальность действия специальных возможностей (измеряется в единицах армии)
		/// </summary>
		int Range { get; }
		/// <summary>
		/// Мощность специальных возможностей
		/// </summary>
		int Power { get; }
		/// <summary>
		/// Вероятность воспользоваться специальной возможностью
		/// </summary>
        int Chance { get; }


        #endregion

        #region Методы

        /// <summary>
        /// Применить специальную возможность
        /// </summary>
        void DoSpecialAction(IArmy targetArmy, int unitPosition);

		#endregion
	}
}
