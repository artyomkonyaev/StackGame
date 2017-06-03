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
        private GulyayGorod wall;

		/// <summary>
		/// Здоровье
		/// </summary>
        public override int Health
        {
            get 
            {
                return wall.GetCurrentHealth();
            }
        }
		/// <summary>
		/// Максимальное здоровье
		/// </summary>
		public override int MaxHealth
        {
            get
            {
                return wall.GetHealth();
            }
        }
		/// <summary>
		/// Защита
		/// </summary>
		public override int Defence
        {
            get
            {
                return wall.GetDefence();    
            }
        }

		/// <summary>
		/// Сила
		/// </summary>
		public override int Strength
        {
            get
            {
                return wall.GetStrength();
            }
        }

		/// <summary>
		/// Есть ли еще здоровье
		/// </summary>
		public override bool IsAlive
		{
			get
			{
                return !wall.IsDead;
			}
		}

		#endregion

		#region Инициализация

		public WallUnit() : base(300, 0)
        {
            wall = new GulyayGorod(300, 0, 100);
        }

		#endregion

		#region Методы

		/// <summary>
		/// Получить урон
		/// </summary>
		public override void GetDamage(int damage)
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
