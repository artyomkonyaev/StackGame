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
        public virtual int Health { get; set; }
        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        public virtual int MaxHealth { get; }
        /// <summary>
        /// Защита
        /// </summary>
        public virtual int Defence { get; }

		/// <summary>
		/// Сила
		/// </summary>
		public virtual int Strength { get; }

		/// <summary>
		/// Есть ли еще здоровье
		/// </summary>
		public virtual bool IsAlive => Health != 0;
		/// <summary>
		/// Поврежден ли
		/// </summary>
        public bool IsDamaged => Health < MaxHealth;

		#endregion

		#region Инициализация

        protected Unit(int defence)
        {
            Defence = defence;
        }

		protected Unit(int health, int defence, int strength)
        {
            Health = health;
            MaxHealth = health;
            Defence = defence;
            Strength = strength;
        }

		#endregion

		#region Методы

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
