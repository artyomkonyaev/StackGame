using System;
using System.Collections.Generic;
using System.Linq;
using StackGame.Core.Configs;
using StackGame.Units;
using StackGame.Units.Creators;

namespace StackGame.Army.Factory
{
    /// <summary>
    /// Фабрика единиц армии
    /// </summary>
    public class RandomUnitsFactory : IArmyFactory
    {
		#region Свойства

		/// <summary>
		/// Получить минимальную стоимость единицы армии
		/// </summary>
		private int MinCost => Configs.Units.Select(unitConfigs => unitConfigs.Value.Price).Min();

		#endregion

		#region Методы

		/// <summary>
		/// Создать армию
		/// </summary>
		public List<IUnit> CreateArmy(int money)
		{
			var random = new Random();

			var unitMinCost = MinCost;

			var units = new List<IUnit>();
			while (money >= unitMinCost)
			{
				var availableTypes = GetUnitTypesWithCostLessThanOrEqual(money);
				var index = random.Next(availableTypes.Length);

				var unitType = availableTypes[index];

				var unit = CreateUnit(unitType);
				units.Add(unit);

				money -= GetCost(unitType);
			}

			return units;
		}

		/// <summary>
		/// Получить типы единиц армии, чья стоимость ниже указанной
		/// </summary>
		private UnitType[] GetUnitTypesWithCostLessThanOrEqual(int maxCost) 
        {
            return Configs.Units.Where(unitConfigs => unitConfigs.Value.Price <= maxCost).Select(unitConfigs => unitConfigs.Key).ToArray();
        }

        /// <summary>
        /// Создать единицу армии
        /// </summary>
        private IUnit CreateUnit(UnitType unitType)
        {
            var creator = GetCreator(unitType);
            return creator.Create();
        }

        /// <summary>
        /// Получить стоимость единицы армии
        /// </summary>
        private int GetCost(UnitType unitType)
        {
            return Configs.Units[unitType].Price;
        }

        /// <summary>
        /// Получить создателя единицы армии
        /// </summary>
        private IUnitCreator GetCreator(UnitType unitType)
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
