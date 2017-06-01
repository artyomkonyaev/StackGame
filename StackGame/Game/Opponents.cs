using StackGame.Units;

namespace StackGame.Game
{
    /// <summary>
    /// Противники
    /// </summary>
    public struct Opponents
    {
        #region Свойства

        /// <summary>
        /// Единица первой армии
        /// </summary>
        public IUnit FirstArmyUnit { get; private set; }
        /// <summary>
        /// Единица второй армии
        /// </summary>
        public IUnit SecondArmyUnit { get; private set; }

		#endregion

		#region Инициализация

        public Opponents(IUnit firstArmyUnit, IUnit secondArmyUnit) 
        {
            FirstArmyUnit = firstArmyUnit;
            SecondArmyUnit = secondArmyUnit;
        }

		#endregion

		#region Методы

		/// <summary>
		/// Поменять единицы армий местами
		/// </summary>
		public Opponents Reverse() 
        {
            var opponents = new Opponents(SecondArmyUnit, FirstArmyUnit);
            return opponents;
        }

		#endregion
	}
}
