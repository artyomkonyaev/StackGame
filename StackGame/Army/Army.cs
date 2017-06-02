using System;
using System.Collections.Generic;
using StackGame.Units;
using StackGame.Units.Factory;

namespace StackGame.Army
{
    /// <summary>
    /// Армия
    /// </summary>
    public class Army : IArmy
    {
        #region Свойства

        /// <summary>
        /// Единицы армии
        /// </summary>
        public List<IUnit> Units { get; private set; }

		/// <summary>
		/// Все ли единицы армии мертвы
		/// </summary>
		public bool IsAllDead 
        {
            get
            {
                return Units.Count == 0;
            }
        }

        /// <summary>
        /// Название армии
        /// </summary>
        protected string name;

		#endregion

		#region Инициализация

		public Army(string name)
		{
            Units = CreateArmy(1000);
            this.name = name;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Создать армию
		/// </summary>
        protected List<IUnit> CreateArmy(int money) 
        {
            var random = new Random();

            var unitMinCost = UnitsFactory.MinCost;

            var units = new List<IUnit>();
            while (money >= unitMinCost) 
            {
                var availableTypes = UnitsFactory.GetUnitTypesWithCostLessThanOrEqual(money);
                var index = random.Next(availableTypes.Length);

                var unitType = availableTypes[index];

                var unit = UnitsFactory.CreateUnit(unitType);
                units.Add(unit);

                money -= UnitsFactory.GetCost(unitType);
            }

            return units;
        }

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
        public override string ToString() {
            string army = $"Армия: { name }\n";
            foreach (var unit in Units) 
            {
                army += unit.ToString() + "\n";
            }

            return army;
        }

		#endregion
	}
}
