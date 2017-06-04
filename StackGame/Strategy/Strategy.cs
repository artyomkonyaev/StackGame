using System;
using System.Collections.Generic;
using StackGame.Core.Engine;
using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Strategy
{
    /// <summary>
    /// Стратегия
    /// </summary>
    public abstract class Strategy : IStrategy
    {
        #region Методы

        public abstract List<MeleeOpponents> GetOpponentsQueue(IArmy firstArmy, IArmy secondArmy);

        public abstract IEnumerable<int> GetUnitsRangeForSpecialAbility(IArmy army, ISpecialAbility unit, int unitPosition);

        /// <summary>
        /// Получить начальный и конечный индексы во вражеской армии
        /// </summary>
        protected abstract Tuple<int, int> GetBoundsInEmemyArmy(IArmy army, int unitPosition, int unitRange);

		/// <summary>
		/// Получить начальный и конечный индексы в армии союзников
		/// </summary>
		protected abstract Tuple<int, int> GetBoundsInAllyArmy(IArmy army, int unitPosition, int unitRange);

		#endregion
	}
}
