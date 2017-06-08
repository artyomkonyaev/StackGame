using System;
using System.Collections.Generic;
using StackGame.Core.Configs;
using StackGame.Army.Factory;
using StackGame.Units;

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
		public bool IsAllDead => Units.Count == 0;

        /// <summary>
        /// Название армии
        /// </summary>
        private readonly string name;

		#endregion

		#region Инициализация

        public Army(string name, IArmyFactory factory, int cost)
		{
            Units = factory.CreateArmy(cost);
            this.name = name;
		}

		#endregion

		#region Методы

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
