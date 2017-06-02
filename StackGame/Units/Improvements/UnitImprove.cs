using System;
using StackGame.Units.Abilities;

namespace StackGame.Units.Improvements
{
    /// <summary>
    /// Улучшаемая единица армии
    /// </summary>
    public abstract class UnitImprove<T> : IUnit, IImprovable, IClonable where T : IUnit, IImprovable, IClonable
    {
        #region Свойства

        /// <summary>
        /// Улучшаемая единица армии
        /// </summary>
        protected T unit;

		public int Health {
            get 
            {
                return unit.Health;
            }
        }
		public virtual int Defence {
            get 
            {
                return unit.Defence;
            }
        }

		public virtual int Strength
        {
            get
            {
                return unit.Strength;
            }
        }

		public bool IsAlive
		{
			get
			{
                return unit.IsAlive;
			}
		}

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

		public virtual void GetDamage(int damage)
		{
            unit.GetDamage(damage);
		}

		public override string ToString()
		{
            return unit.ToString();
		}

		#endregion
	}
}
