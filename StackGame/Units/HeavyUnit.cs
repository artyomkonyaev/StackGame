using System;
using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Тяжелый пехотинец
    /// </summary>
    public class HeavyUnit : Unit, IImprovable, IClonable
    {
		#region Инициализация

		public HeavyUnit() : base(100, 10)
        {
            Defence = 100;
        }

		#endregion

		#region Методы

        public bool CanImprove(Type type)
        {
            return true;
        }

		public IUnit Clone()
		{
			return (IUnit)MemberwiseClone();
		}

		public override void TakeDamage(int damage)
		{
            if (Defence > 0)
            {
                Defence -= damage;
                if (Defence < 0) {
                    base.TakeDamage(Math.Abs(Defence));
                    Defence = 0;
                }
            }
            else
            {
                base.TakeDamage(damage);
            }
		}

		public override string ToString()
		{
			return $"Тяжелый пехотинец: { base.ToString() }";
		}

		#endregion
	}
}
