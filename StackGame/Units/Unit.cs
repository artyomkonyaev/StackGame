namespace StackGame.Units
{
	/// <summary>
	/// Единица армии
	/// </summary>
	public abstract class Unit : IUnit
    {
		#region Свойства

		/// <summary>
		/// Здоровье
		/// </summary>
        public virtual int Health { get; protected set; }
        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        public virtual int MaxHealth { get; }
        /// <summary>
        /// Защита
        /// </summary>
        public virtual int Defence { get; protected set; } = 0;

		/// <summary>
		/// Сила
		/// </summary>
		public virtual int Strength { get; }

		/// <summary>
		/// Есть ли еще здоровье
		/// </summary>
		public virtual bool IsAlive => Health != 0;

		#endregion

		#region Инициализация

		protected Unit(int health, int strength)
        {
            Health = health;
            MaxHealth = health;
            Strength = strength;
        }

		#endregion

		#region Методы

		/// <summary>
		/// Получить урон
		/// </summary>
        public virtual void TakeDamage(int damage) 
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
        public override string ToString()
        {
            return $"Здоровье { Health }, Защита { Defence }, Сила { Strength }";
        }

		#endregion
	}
}
