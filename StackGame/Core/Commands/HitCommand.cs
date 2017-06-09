using StackGame.Loggers;
using StackGame.Units;

namespace StackGame.Core.Commands
{
    /// <summary>
    /// Команда "атаковать"
    /// </summary>
    public class HitCommand : ICommand
    {
        #region Свойства

        /// <summary>
        /// Единица армии, наносящая урон
        /// </summary>
        private readonly IUnit unit;
        /// <summary>
        /// Вражеская единица армии
        /// </summary>
        private readonly IUnit enemyUnit;
        /// <summary>
        /// Максимальный возможный урон
        /// </summary>
        private readonly int maxDamage;

        /// <summary>
        /// Реальный урон
        /// </summary>
        private int damage;

		#endregion

		#region Инициализация

        public HitCommand(IUnit unit, IUnit enemyUnit, int maxDamage)
		{
            this.unit = unit;
            this.enemyUnit = enemyUnit;
            this.maxDamage = maxDamage;

            damage = maxDamage;
		}

		#endregion

		#region Методы

		public void Execute(ILogger logger)
		{
			damage = maxDamage * (100 - enemyUnit.Defence) / 100;
			if (damage > enemyUnit.Health)
			{
				damage = enemyUnit.Health;
			}

            enemyUnit.TakeDamage(damage);

			var message = $"🗡  { unit } нанес { damage } урона { enemyUnit }";
			logger.Log(message);

            if (!enemyUnit.IsAlive)
            {
				message = $"☠️  { enemyUnit } умер";
				logger.Log(message);
            }
        }

		public void Undo(ILogger logger)
		{ 
            enemyUnit.Health += damage;
        }

		#endregion
	}
}
