using System;
using StackGame.Loggers;
using StackGame.Army;
using StackGame.Units;

namespace StackGame.Commands
{
    /// <summary>
    /// Команда "улучшить"
    /// </summary>
    public class ImproveCommand : ICommand
    {
		#region Свойства

		/// <summary>
		/// Единица армии, выполняющая улучшение
		/// </summary>
		private readonly IUnit unit;
		/// <summary>
		/// Улучшаемая единица армии
		/// </summary>
		private readonly IUnit targetUnit;
		/// <summary>
		/// Армия, в которой находится улучшаемая единица армии
		/// </summary>
        private readonly IArmy army;
        /// <summary>
        /// Позиция улучшаемой единицы армии
        /// </summary>
        private readonly int targetUnitPosition;
        /// <summary>
        /// Улучшение
        /// </summary>
        private readonly Type unitImprove;

		#endregion

		#region Инициализация

		public ImproveCommand(IUnit unit, IUnit targetUnit, IArmy army, int targetUnitPosition, Type unitImprove)
		{
			this.unit = unit;
			this.targetUnit = targetUnit;
			this.army = army;
            this.targetUnitPosition = targetUnitPosition;
			this.unitImprove = unitImprove;
		}

		#endregion

		#region Методы

		public void Execute(ILogger logger)
		{
			var improvementUnit = (IUnit)Activator.CreateInstance(unitImprove, targetUnit);
            army.Units[targetUnitPosition] = improvementUnit;

			var message = $"\ud83d\udecd #{ unit }# надел { unitImprove.GetGenericTypeDefinition() } на #{ targetUnit }#";
			logger.Log(message);
		}

		public void Undo(ILogger logger)
		{
			army.Units[targetUnitPosition] = targetUnit;
		}

		#endregion
    }
}
