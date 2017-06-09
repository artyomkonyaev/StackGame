using System;
using System.Collections.Generic;
using System.Linq;
using StackGame.Core.Engine;
using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Strategy
{
    /// <summary>
    /// Стратегия "все со всеми"
    /// </summary>
    public class StrategyAllVsAll : IStrategy
    {
		#region Методы

		public List<MeleeOpponents> GetOpponentsQueue(IArmy firstArmy, IArmy secondArmy)
		{
			var firstArmyUnitsCount = firstArmy.Units.Count;
			var secondArmyUnitsCount = secondArmy.Units.Count;
            var minCount = Math.Min(firstArmyUnitsCount, secondArmyUnitsCount);

			var queue = new List<MeleeOpponents>();
			for (int i = 0; i < minCount; i++)
			{
				var opponents = new MeleeOpponents(firstArmy, i, secondArmy, i);
				var _queue = new List<MeleeOpponents>
				{
					opponents,
					opponents.Reverse()
				};

				queue = queue.Concat(_queue.Randomize()).ToList();
			}

			return queue;
		}

		public IEnumerable<int> GetUnitsRangeForSpecialAbility(IArmy army, IArmy enemyArmy, ISpecialAbility unit, int unitPosition)
		{
			var isFirst = unitPosition < enemyArmy.Units.Count;
			if (isFirst)
			{
				return null;
			}

			var targetArmy = unit.IsFriendly ? army : enemyArmy;
			var radius = unit.Range;

			Tuple<int, int> bounds;
			if (unit.IsFriendly)
			{
				bounds = GetBoundsInAllyArmy(targetArmy, unitPosition, radius);
			}
			else
			{
				if (unitPosition - radius >= targetArmy.Units.Count)
				{
					return null;
				}

				bounds = GetBoundsInEmemyArmy(targetArmy, unitPosition, radius);
			}

			var startIndex = bounds.Item1;
			var endIndex = bounds.Item2;

			var count = endIndex - startIndex + 1;

			if (count == 0)
			{
				return null;
			}

			var range = Enumerable.Range(startIndex, count);
			return range;
		}

		/// <summary>
		/// Получить начальный и конечный индексы в армии союзников
		/// </summary>
		private Tuple<int, int> GetBoundsInAllyArmy(IArmy army, int unitPosition, int unitRange)
		{
			var startIndex = unitPosition - unitRange;
			if (startIndex < 0)
			{
				startIndex = 0;
			}

			var endIndex = unitPosition + unitRange;
			if (endIndex >= army.Units.Count)
			{
				endIndex = army.Units.Count - 1;
			}

			return new Tuple<int, int>(startIndex, endIndex);
		}

		/// <summary>
		/// Получить начальный и конечный индексы во вражеской армии
		/// </summary>
		private Tuple<int, int> GetBoundsInEmemyArmy(IArmy army, int unitPosition, int unitRange)
		{
			var startIndex = unitPosition - unitRange;
			if (startIndex < 0)
			{
				startIndex = 0;
			}

			var endIndex = Math.Abs(unitRange - unitPosition) + 1 + unitRange;
			if (endIndex >= army.Units.Count)
			{
				endIndex = army.Units.Count - 1;
			}

			return new Tuple<int, int>(startIndex, endIndex);
		}

		#endregion
	}
}
