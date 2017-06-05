using System;
using System.Collections.Generic;
using System.Linq;
using StackGame.Core.Engine;
using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Strategy
{
    /// <summary>
    /// Стратегия "n на n"
    /// </summary>
    public class StrategyNVsN : IStrategy
    {
        #region Свойства

        /// <summary>
        /// Количество единиц армии в ряду
        /// </summary>
        private readonly int n;

		#endregion

		#region Инициализация

		public StrategyNVsN(int n)
		{
            this.n = n;
		}

		#endregion

		#region Методы

		public List<MeleeOpponents> GetOpponentsQueue(IArmy firstArmy, IArmy secondArmy)
		{
			var firstArmyUnitsCount = firstArmy.Units.Count;
			var secondArmyUnitsCount = secondArmy.Units.Count;
			var minCount = Math.Min(firstArmyUnitsCount, secondArmyUnitsCount);

            var min = Math.Min(n, minCount);

			var queue = new List<MeleeOpponents>();
			for (int i = 0; i < min; i++)
			{
				var opponents = new MeleeOpponents(firstArmy.Units[i], secondArmy.Units[i]);
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
            var min = Math.Min(n, enemyArmy.Units.Count);
			var isFirst = unitPosition < min;
			if (isFirst)
			{
				return null;
			}

			var targetArmy = unit.IsFriendly ? army : enemyArmy;
			var radius = unit.Range;

            int unitX;
            int unitY;
			if (unit.IsFriendly)
			{
				unitX = unitPosition % n;
				unitY = unitPosition / n;
			}
            else
            {
                var searchRange = radius - unitPosition / n - 1;
				if (searchRange < 0)
				{
					return null;
				}

                unitX = Math.Abs(unitPosition % n - (n - 1));
                unitY = -unitPosition / n - 1;
            }

			var indexes = GetIndexesInArea(targetArmy, unitPosition, unitX, unitY, radius);
			if (indexes != null)
			{
                return indexes;
			}

			return null;
		}

        /// <summary>
        /// Получить индексы в области воздействия специальной возможности
        /// </summary>
        private List<int> GetIndexesInArea(IArmy army, int unitPosition, int unitX, int unitY, int unitRange)
        {
			var startIndex = unitPosition - unitRange * n;
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            var endIndex = unitPosition + unitRange * n;
            if (endIndex >= army.Units.Count)
            {
                endIndex = army.Units.Count - 1;
            }

            var count = endIndex - startIndex + 1;

			if (count == 0)
			{
				return null;
			}

            var indexes = new List<int>();

            var range = Enumerable.Range(startIndex, count);
            foreach (var index in range)
            {
                var indexX = index % n;
                var indexY = index / n;

                var isInOrOnRadius = Math.Pow(indexX - unitX, 2) + Math.Pow(indexY - unitY, 2) <= Math.Pow(unitRange, 2);
                if (isInOrOnRadius)
                {
                    indexes.Add(index);
                }
            }

            return indexes;
        }

		#endregion
	}
}
