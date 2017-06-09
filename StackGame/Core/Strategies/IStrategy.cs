using System.Collections.Generic;
using StackGame.Core.Engine;
using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Core.Strategies
{
    /// <summary>
    /// Интерфейс стратегии боя
    /// </summary>
    public interface IStrategy
    {
        #region Методы

        /// <summary>
        /// Получить очередь рукопашных противников
        /// </summary>
        List<MeleeOpponents> GetOpponentsQueue(IArmy firstArmy, IArmy secondArmy);
        /// <summary>
        /// Получить индексы единиц армии, поподаюших под воздействие специальных возможностей
        /// </summary>
        IEnumerable<int> GetUnitsRangeForSpecialAbility(IArmy army, IArmy enemyArmy, ISpecialAbility unit, int unitPosition);

        #endregion
    }
}
