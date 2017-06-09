using System.Collections.Generic;
using StackGame.Core.Engine;
using StackGame.Commands;
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
		public bool IsAllDead => Units.IsEmpty();

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
		/// Удалить мертвые единицы армии
		/// </summary>
		public int CollectDeadUnits()
        {
			var deadUnits = new List<KeyValuePair<int, IUnit>>();
			for (var i = 0; i < Units.Count; i++)
			{
				var unit = Units[i];
				if (!unit.IsAlive)
				{
					var pair = new KeyValuePair<int, IUnit>(i, unit);
					deadUnits.Add(pair);
				}
			}

            if (!deadUnits.IsEmpty()) {
				var command = new CollectDeadCommand(this, deadUnits);
				Engine.GetInstance().CommandManager.Execute(command);
            }

            return deadUnits.Count;
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
