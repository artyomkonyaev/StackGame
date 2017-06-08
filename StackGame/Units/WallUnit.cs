using System.Reflection;
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
        public override int Health
        {
            get => wall.GetCurrentHealth();
            set
            {
                if (value < Health)
                {
                    var damage = Health - value;
                    wall.TakeDamage(damage);
                }
                else
                {
                    wall.GetType().GetField("_currentHealth", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(wall, value);
                }
            }
        }
        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        public override int MaxHealth => wall.GetHealth();

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

		public WallUnit(int health, int defence, int price) : base(defence)
        {
            wall = new GulyayGorod(health, 0, price);
        }

		#endregion

		#region Методы

		public override string ToString()
		{
			return $"Стена: { base.ToString() }";
		}

		#endregion
	}
}
