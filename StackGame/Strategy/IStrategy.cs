using System.Collections.Generic;
using StackGame.Core.Engine;
using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Strategy
{
    /// <summary>
    /// Интерфейс стратегии боя
    /// </summary>
    public interface IStrategy
    {
        #region Методы

        /// <summary>
        /// Получить противников
        /// </summary>
        List<MeleeOpponents> GetOpponentsQueue(IArmy firstArmy, IArmy secondArmy);
        /// <summary>
        /// Получить индексы единиц армии, поподаюших под воздействие специальных возможностей
        /// </summary>
        IEnumerable<int> GetUnitsRangeForSpecialAbility(IArmy army, ISpecialAbility unit, int unitPosition);

        #endregion
    }
}
