using System.Collections.Generic;
using StackGame.Observers;

namespace StackGame.Units
{
	/// <summary>
	/// Единица армии
	/// </summary>
    public abstract class Unit : IUnit, IObservable
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
		public virtual bool IsAlive => Health > 0;
		/// <summary>
		/// Поврежден ли
		/// </summary>
        public bool IsDamaged => Health < MaxHealth;

        /// <summary>
        /// Наблюдатели
        /// </summary>
        internal List<IObserver> observers = new List<IObserver>();

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
		/// Получить урон
		/// </summary>
		public void TakeDamage(int damage)
        {
            Health -= damage;

            if (!IsAlive)
			{
                var message = $"☠️ { this } умер";
                NotifyObservers(message);
            }
        }

		/// <summary>
		/// Зарегистрировать наблюдателя
		/// </summary>
		public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

		/// <summary>
		/// Удалить наблюдателя
		/// </summary>
		public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

		/// <summary>
		/// Уведомить наблюдателя
		/// </summary>
		public void NotifyObservers(object @object)
        {
            foreach (var observer in observers)
            {
                observer.Update(@object);
            }
        }

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
        public override string ToString()
        {
            return $"(здоровье { Health }, защита { Defence }, сила { Strength })";
        }

		#endregion
	}
}
