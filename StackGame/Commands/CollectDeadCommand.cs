using System.Collections.Generic;
using StackGame.Army;
using StackGame.Units;

namespace StackGame.Commands
{
    /// <summary>
    /// Команда "убрать мертвых"
    /// </summary>
    public class CollectDeadCommand : ICommand
    {
		#region Свойства

		/// <summary>
		/// Армия, в которой нужно собрать мертвых
		/// </summary>
		private readonly IArmy army;

        /// <summary>
        /// Мертвые
        /// </summary>
        private List<KeyValuePair<int, IUnit>> deadUnits;

		#endregion

		#region Инициализация

        public CollectDeadCommand(IArmy army)
		{
			this.army = army;
		}

		#endregion

		#region Методы

		public void Execute()
		{
			deadUnits = new List<KeyValuePair<int, IUnit>>();
			for (var i = 0; i < army.Units.Count; i++)
			{
				var unit = army.Units[i];
				if (!unit.IsAlive)
				{
					var pair = new KeyValuePair<int, IUnit>(i, unit);
					deadUnits.Add(pair);
				}
			}

            foreach (var pair in deadUnits)
            {
                army.Units.RemoveAt(pair.Key);
            }
		}

		public void Undo()
		{
			foreach (var pair in deadUnits)
			{
                army.Units.Insert(pair.Key, pair.Value);
			}
		}

		#endregion
	}
}
