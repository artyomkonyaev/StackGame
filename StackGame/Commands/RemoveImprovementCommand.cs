using System;
using StackGame.Army;
using StackGame.Units;
using StackGame.Units.Abilities;
using StackGame.Units.Improvements;

namespace StackGame.Commands
{
	/// <summary>
	/// Команда "удалить улучшение"
	/// </summary>
	public class RemoveImprovementCommand : ICommand
    {
		#region Свойства

		/// <summary>
		/// Единица армии, у которой нужно удалить улучшение
		/// </summary>
		private readonly IImprovable unit;
		/// <summary>
		/// Армия
		/// </summary>
		private readonly IArmy army;
		/// <summary>
		/// Позиция единицы армии
		/// </summary>
		private readonly int unitPosition;

		#endregion

		#region Инициализация

        public RemoveImprovementCommand(IImprovable unit, IArmy army, int unitPosition)
		{
			this.unit = unit;
			this.army = army;
			this.unitPosition = unitPosition;
		}

		#endregion

		#region Методы

		public void Execute()
		{
            var baseUnit = ((IUnitImprove)unit).Unit;
            army.Units[unitPosition] = baseUnit;

            Console.WriteLine($"\ud83d\uddd1 #{ baseUnit }# потерял { unit.GetType().GetGenericTypeDefinition() }");
        }

		public void Undo()
		{
            army.Units[unitPosition] = (IUnit)unit;
		}

		#endregion
	}
}
