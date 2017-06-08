﻿using StackGame.Army;

namespace StackGame.Core.Engine
{
    /// <summary>
    /// Рукопашные противники
    /// </summary>
    public struct MeleeOpponents
    {
        #region Свойства

        /// <summary>
        /// Армия
        /// </summary>
        public IArmy Army { get; private set; }
        /// <summary>
        /// Позиция единицы армии
        /// </summary>
        public int UnitPosition { get; private set; }
		/// <summary>
		/// Вражеская армия
		/// </summary>
		public IArmy EnemyArmy { get; private set; }
		/// <summary>
		/// Позиция вражеской единицы армии
		/// </summary>
		public int EnemyUnitPosition { get; private set; }

		#endregion

		#region Инициализация

        public MeleeOpponents(IArmy army, int unitPosition, IArmy enemyArmy, int enemyUnitPosition) 
        {
            Army = army;
            UnitPosition = unitPosition;
            EnemyArmy = enemyArmy;
            EnemyUnitPosition = enemyUnitPosition;
        }

		#endregion

		#region Методы

		/// <summary>
		/// Поменять единицы армий местами
		/// </summary>
		public MeleeOpponents Reverse() 
        {
            var opponents = new MeleeOpponents(EnemyArmy, EnemyUnitPosition, Army, UnitPosition);
            return opponents;
        }

		#endregion
	}
}
