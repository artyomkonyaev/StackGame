using System;

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
        public virtual int Defence { get; protected set; }

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
		/// Получить урон
		/// </summary>
        public virtual void TakeDamage(int damage) 
        {
			if (Defence > 0)
			{
				Defence -= damage;
				if (Defence < 0)
				{
					Health -= Math.Abs(Defence);
					Defence = 0;
				}
			}
			else
			{
				Health -= damage;
			}

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
