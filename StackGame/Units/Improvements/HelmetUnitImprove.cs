using System;
using StackGame.Units.Abilities;

namespace StackGame.Units.Improvements
{
    /// <summary>
    /// Шлем
    /// </summary>
    public class HelmetUnitImprove<T> : UnitImprove<T> where T : IUnit, IImprovable, IClonable
    {
        #region Свойства

        /// <summary>
        /// Защита шлема
        /// </summary>
        private int helmetDefence = 20;

        public override int Defence => base.Defence + helmetDefence;

		#endregion

		#region Инициализация

		public HelmetUnitImprove(T unit) : base(unit)
        { }

		#endregion

		#region Методы

		public override IUnit Clone()
		{
			var clonedUnit = (T)unit.Clone();
			var improvedClonedUnit = new HelmetUnitImprove<T>(clonedUnit);

			return improvedClonedUnit;
		}

		public override void TakeDamage(int damage)
		{
			if (helmetDefence > 0)
			{
				helmetDefence -= damage;
				if (helmetDefence < 0)
				{
					base.TakeDamage(Math.Abs(helmetDefence));
					helmetDefence = 0;
				}
			}
			else
			{
				base.TakeDamage(damage);
			}
		}

		public override string ToString()
		{
            return $"{ base.ToString() } |шлем { helmetDefence }|";
		}

		#endregion
    }
}
