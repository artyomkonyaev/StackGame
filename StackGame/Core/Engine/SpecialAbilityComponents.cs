using System.Collections.Generic;
using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Core.Engine
{
    /// <summary>
    /// Элементы задействованные специальными возможностями
    /// </summary>
    public struct SpecialAbilityComponents
    {
		#region Свойства

		/// <summary>
		/// Единица армии применяющая специальные возможности
		/// </summary>
        public ISpecialAbility Unit { get; private set; }
		/// <summary>
		/// Армия, попадающая под воздействие специальных возможностей
		/// </summary>
        public IArmy Army { get; private set; }
        /// <summary>
        /// Индексы единиц армии, попадающих под область действия специальных возможностей
        /// </summary>
        public IEnumerable<int> Range { get; private set; }
        /// <summary>
        /// Позиция единицы армии, применяющей специальные возможности
        /// </summary>
        public int Position { get; private set; }

		#endregion

		#region Инициализация

		public SpecialAbilityComponents(ISpecialAbility unit, IArmy army, IEnumerable<int> range, int position)
		{
			Unit = unit;
            Army = army;
            Range = range;
            Position = position;
		}

		#endregion
	}
}
