using System;
using StackGame.Units.Abilities;

namespace StackGame.Units.Improvements
{
    /// <summary>
    /// Улучшение единицы армии
    /// </summary>
    public abstract class UnitImprove<T> : IUnit, IImprovable, IClonable where T : IUnit, IImprovable, IClonable
    {
        #region Свойства

        /// <summary>
        /// Улучшаемая единица армии
        /// </summary>
        public T Unit { get; protected set; }

		public int Health
        {
            get => Unit.Health;
            set => Unit.Health = value;
        }
        public int MaxHealth => Unit.MaxHealth;
        public virtual int Defence => Unit.Defence;

        public virtual int Strength => Unit.Strength;

		public bool IsAlive => Unit.IsAlive;
        public bool IsDamaged => Unit.IsDamaged;

		#endregion

		#region Инициализация

        protected UnitImprove(T unit)
		{
            Unit = unit;
		}

        #endregion

        #region Методы

        public bool CanImprove(Type type)
        {
            if (GetType().GetGenericTypeDefinition() == type)
            {
                return false;
            }

            return Unit.CanImprove(type);
        }

        public abstract IUnit Clone();

		public void TakeDamage(int damage)
		{
            Unit.TakeDamage(damage);
		}

		public override string ToString()
		{
            return Unit.ToString();
		}

		#endregion
	}
}
