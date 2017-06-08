using System.Collections.Generic;
using StackGame.Units;

namespace StackGame.Army.Factory
{
    public interface IArmyFactory
    {
		#region Методы

		/// <summary>
		/// Создать армию
		/// </summary>
		List<IUnit> CreateArmy(int money);

        #endregion
	}
}
