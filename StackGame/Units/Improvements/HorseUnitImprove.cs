using System;
using StackGame.Core.Configs;
using StackGame.Units.Abilities;

namespace StackGame.Units.Improvements
{
    /// <summary>
	/// Лошадь
	/// </summary>
	public class HorseUnitImprove<T> : UnitImprove<T> where T : IUnit, IImprovable, IClonable
	{
        #region Свойства

        /// <summary>
        /// Жизнь лошади
        /// </summary>
        private int horseHealth;
        /// <summary>
        /// Сила лошади
        /// </summary>
        private int horseStrength;

		public override int Defence => base.Defence + horseHealth;

		public override int Strength => base.Strength + horseStrength;

		#endregion

		#region Инициализация

		public HorseUnitImprove(T unit) : base(unit)
		{
            var parameters = Configs.UnitImproves[UnitImproveType.Horse];
            horseHealth = parameters.Health;
            horseStrength = parameters.Strength;
        }

		#endregion

		#region Методы

		public override IUnit Clone()
		{
			var clonedUnit = (T)unit.Clone();
			var improvedClonedUnit = new HorseUnitImprove<T>(clonedUnit);

			return improvedClonedUnit;
		}

		public override void TakeDamage(int damage)
		{
			if (horseHealth > 0)
			{
				horseHealth -= damage;
				if (horseHealth < 0)
				{
					base.TakeDamage(Math.Abs(horseHealth));
					horseHealth = 0;
				}
			}
			else
			{
				base.TakeDamage(damage);
			}
		}

		public override string ToString()
		{
            return $"{ base.ToString() } |лошадь - здоровье { horseHealth }, атака { horseStrength }|";
		}

		#endregion
	}
}
