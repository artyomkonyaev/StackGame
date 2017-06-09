using StackGame.Loggers;
using StackGame.Army;
using StackGame.Units;
using StackGame.Units.Abilities;

namespace StackGame.Core.Commands
{
    /// <summary>
    /// Команда "клонировать"
    /// </summary>
    public class CloneCommand : ICommand
    {
		#region Свойства

		/// <summary>
		/// Единица армии, выполняющая улучшение
		/// </summary>
		private readonly IUnit unit;
		/// <summary>
		/// Улучшаемая единица армии
		/// </summary>
		private readonly IClonable targetUnit;
		/// <summary>
		/// Армия, в которой находится улучшаемая единица армии
		/// </summary>
		private readonly IArmy army;

		#endregion

		#region Инициализация

		public CloneCommand(IUnit unit, IClonable targetUnit, IArmy army)
		{
			this.unit = unit;
			this.targetUnit = targetUnit;
			this.army = army;
		}

		#endregion

		#region Методы

		public void Execute(ILogger logger)
		{
			var clonedUnit = targetUnit.Clone();
			army.Units.Add(clonedUnit);

            var message = $"🔮 { unit } клонировал { targetUnit }";
            logger.Log(message);
		}

		public void Undo(ILogger logger)
		{
            army.Units.RemoveAt(army.Units.Count - 1);
		}

		#endregion
	}
}
