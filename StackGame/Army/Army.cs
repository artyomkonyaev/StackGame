using System.Collections.Generic;
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
        /// Название армии
        /// </summary>
        private string name;

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
        List<IUnit> CreateArmy(int cost) 
        {
            return new List<IUnit>();
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
