using SpecialUnits;

namespace StackGame.Units
{
    /// <summary>
    /// Стена
    /// </summary>
    public class WallUnit : Unit
    {
        #region Свойства

        /// <summary>
        /// Гуляй-город
        /// </summary>
        private readonly GulyayGorod wall;

        /// <summary>
        /// Здоровье
        /// </summary>
        public override int Health => wall.GetCurrentHealth();
        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        public override int MaxHealth => wall.GetHealth();
		/// <summary>
		/// Защита
		/// </summary>
		public override int Defence => wall.GetDefence();

		/// <summary>
		/// Сила
		/// </summary>
		public override int Strength => wall.GetStrength();

		/// <summary>
		/// Есть ли еще здоровье
		/// </summary>
		public override bool IsAlive => !wall.IsDead;

		#endregion

		#region Инициализация

		public WallUnit(int health, int defence, int price) : base(health, defence, 0)
        {
            wall = new GulyayGorod(health, defence, price);
        }

		#endregion

		#region Методы

		/// <summary>
		/// Получить урон
		/// </summary>
		public override void TakeDamage(int damage)
		{
            wall.TakeDamage(damage);
		}

		public override string ToString()
		{
			return $"Стена: { base.ToString() }";
		}

		#endregion
	}
}
