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
        protected T unit;

		public int Health => unit.Health;
        public virtual int Defence => unit.Defence;

        public virtual int Strength => unit.Strength;

		public bool IsAlive => unit.IsAlive;
        public virtual bool IsDamaged => unit.IsDamaged;

		#endregion

		#region Инициализация

        protected UnitImprove(T unit)
		{
            this.unit = unit;
		}

        #endregion

        #region Методы

        public bool CanImprove(Type type)
        {
            if (GetType().GetGenericTypeDefinition() == type)
            {
                return false;
            }

            return unit.CanImprove(type);
        }

        public abstract IUnit Clone();

		public virtual void TakeDamage(int damage)
		{
            unit.TakeDamage(damage);
		}

		public override string ToString()
		{
            return unit.ToString();
		}

		#endregion
	}
}
