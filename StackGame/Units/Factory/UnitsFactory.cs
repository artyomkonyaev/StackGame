using System;
using System.Linq;
using StackGame.Units.Creators;

namespace StackGame.Units.Factory
{
    /// <summary>
    /// Фабрика единиц армии
    /// </summary>
    public static class UnitsFactory
    {
		#region Свойства

		/// <summary>
		/// Получить минимальную стоимость единицы армии
		/// </summary>
		public static int MinCost => UnitTypes.Select(unitType => GetCost(unitType)).Min();

        /// <summary>
        /// Все типы единиц армии
        /// </summary>
        private static UnitType[] UnitTypes 
        {
            get 
            {
                return (UnitType[])Enum.GetValues(typeof(UnitType));
            }
        }

		#endregion

		#region Методы

		/// <summary>
		/// Получить типы единиц армии, чья стоимость ниже указанной
		/// </summary>
		public static UnitType[] GetUnitTypesWithCostLessThanOrEqual(int maxCost) 
        {
            return UnitTypes.Where(unitType => GetCost(unitType) <= maxCost).ToArray();
        }

        /// <summary>
        /// Создать единицу армии
        /// </summary>
        public static IUnit CreateUnit(UnitType unitType)
        {
            var creator = GetCreator(unitType);
            return creator.Create();
        }

        /// <summary>
        /// Получить стоимость единицы армии
        /// </summary>
        public static int GetCost(UnitType unitType)
        {
            switch (unitType) 
            {
                case UnitType.LightUnit:
                    return 25;
                case UnitType.HeavyUnit:
                    return 50;
                case UnitType.ArcherUnit:
                    return 75;
                case UnitType.ClericUnit:
                    return 75;
                case UnitType.MageUnit:
                    return 100;
                case UnitType.WallUnit:
                    return 100;

                default:
                    return int.MaxValue;
            }
        }

        /// <summary>
        /// Получить создателя единицы армии
        /// </summary>
        private static IUnitCreator GetCreator(UnitType unitType)
        {
			switch (unitType)
			{
				case UnitType.LightUnit:
                    return new LightUnitCreator();
				case UnitType.HeavyUnit:
                    return new HeavyUnitCreator();
                case UnitType.ArcherUnit:
                    return new ArcherUnitCreator();
                case UnitType.ClericUnit:
                    return new ClericUnitCreator();
                case UnitType.MageUnit:
                    return new MageUnitCreator();
                case UnitType.WallUnit:
                    return new WallUnitCreator();

                default:
                    return null;
			}
        }

		#endregion
	}
}
