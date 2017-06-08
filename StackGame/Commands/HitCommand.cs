using System;
using StackGame.Units;

namespace StackGame.Commands
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

		public void Execute()
		{
			damage = maxDamage * (100 - enemyUnit.Defence) / 100;
			if (damage > enemyUnit.Health)
			{
				damage = enemyUnit.Health;
			}

            enemyUnit.Health -= damage;

            Console.WriteLine($"\ud83d\udde1 #{ unit }# нанес { damage } урона #{ enemyUnit }#");

			if (enemyUnit.Health == 0)
			{
				Console.WriteLine($"☠️ #{ enemyUnit }# умер");
			}
        }

		public void Undo()
		{ 
            enemyUnit.Health += damage;
        }

		#endregion
	}
}
