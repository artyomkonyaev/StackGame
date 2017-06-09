using StackGame.Loggers;
using StackGame.Units;
using StackGame.Units.Abilities;

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
		private readonly IHealable targetUnit;
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

		public HealCommand(IUnit unit, IHealable targetUnit, int maxHealthPower)
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
            if (((IUnit)targetUnit).Health + maxHealthPower > ((IUnit)targetUnit).MaxHealth)
            {
                healthPower = ((IUnit)targetUnit).MaxHealth - ((IUnit)targetUnit).Health;
            }

            targetUnit.Heal(healthPower);

            var message = $"\ud83d\udc8a #{ unit }# вылечил на { healthPower } здоровья #{ targetUnit }#";
			logger.Log(message);
		}

		public void Undo(ILogger logger)
		{
			((IUnit)targetUnit).Health -= healthPower;
		}

		#endregion
	}
}
