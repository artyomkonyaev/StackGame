﻿using StackGame.Units;

namespace StackGame.Core.Engine
{
    /// <summary>
    /// Рукопашные противники
    /// </summary>
    public struct MeleeOpponents
    {
        #region Свойства

        /// <summary>
        /// Единица армии
        /// </summary>
        public IUnit Unit { get; private set; }
		/// <summary>
		/// Вражеская единица армии
		/// </summary>
		public IUnit EnemyUnit { get; private set; }

		#endregion

		#region Инициализация

        public MeleeOpponents(IUnit unit, IUnit enemyUnit) 
        {
            Unit = unit;
            EnemyUnit = enemyUnit;
        }

		#endregion

		#region Методы

		/// <summary>
		/// Поменять единицы армий местами
		/// </summary>
		public MeleeOpponents Reverse() 
        {
            var opponents = new MeleeOpponents(EnemyUnit, Unit);
            return opponents;
        }

		#endregion
	}
}
