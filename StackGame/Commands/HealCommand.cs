using System;
using StackGame.Loggers;
using StackGame.Units;

namespace StackGame.Commands
{
	/// <summary>
	/// Команда "лечить"
	/// </summary>
	public class HealCommand : ICommand
    {
		#region Свойства

		/// <summary>
		/// Единица армии, выполняющая лечение
		/// </summary>
		private readonly IUnit unit;
		/// <summary>
		/// Лечимая единица армии
		/// </summary>
		private readonly IUnit targetUnit;
		/// <summary>
		/// Максимальное количество единиц здоровья, что можно восстановить
		/// </summary>
		private readonly int maxHealthPower;

		/// <summary>
		/// Восстановленное количество единиц здоровья
		/// </summary>
		private int healthPower;

		#endregion

		#region Инициализация

		public HealCommand(IUnit unit, IUnit targetUnit, int maxHealthPower)
		{
			this.unit = unit;
			this.targetUnit = targetUnit;
			this.maxHealthPower = maxHealthPower;

			healthPower = maxHealthPower;
		}

		#endregion

		#region Методы

		public void Execute(ILogger logger)
		{
            if (targetUnit.Health + maxHealthPower > targetUnit.MaxHealth)
            {
                healthPower = targetUnit.MaxHealth - targetUnit.Health;
            }

            targetUnit.Health += healthPower;

            var message = $"\ud83d\udc8a #{ unit }# вылечил на { healthPower } здоровья #{ targetUnit }#";
			logger.Log(message);
		}

		public void Undo(ILogger logger)
		{
			targetUnit.Health -= healthPower;
		}

		#endregion
	}
}
