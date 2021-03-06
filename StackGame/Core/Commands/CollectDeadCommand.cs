﻿using System.Collections.Generic;
using System.Linq;
using StackGame.Loggers;
using StackGame.Army;
using StackGame.Units;

namespace StackGame.Core.Commands
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
        private readonly List<KeyValuePair<int, IUnit>> deadUnits;

		#endregion

		#region Инициализация

        public CollectDeadCommand(IArmy army, List<KeyValuePair<int, IUnit>> deadUnits)
		{
			this.army = army;
            this.deadUnits = deadUnits;
		}

		#endregion

		#region Методы

		public void Execute(ILogger logger)
		{
            var _deadUnits = deadUnits.Select(unit => unit).ToList();
            _deadUnits.Reverse();

			foreach (var pair in _deadUnits)
            {
                army.Units.RemoveAt(pair.Key);
            }
		}

		public void Undo(ILogger logger)
		{
			foreach (var pair in deadUnits)
			{
                army.Units.Insert(pair.Key, pair.Value);
			}
		}

		#endregion
	}
}
