using System;
using System.Linq;
using StackGame.Core.Configs;
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
		public static int MinCost => Configs.Units.Select(unitConfigs => unitConfigs.Value.Price).Min();

		#endregion

		#region Методы

		/// <summary>
		/// Получить типы единиц армии, чья стоимость ниже указанной
		/// </summary>
		public static UnitType[] GetUnitTypesWithCostLessThanOrEqual(int maxCost) 
        {
            return Configs.Units.Where(unitConfigs => unitConfigs.Value.Price <= maxCost).Select(unitConfigs => unitConfigs.Key).ToArray();
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
            return Configs.Units[unitType].Price;
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
