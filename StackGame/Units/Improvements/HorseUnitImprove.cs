using System;
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
		private int horseHealth = 50;

		public override int Defence
		{
			get
			{
				return base.Defence + horseHealth;
			}
		}

		public override int Strength
		{
			get
			{
				return base.Strength + 10;
			}
		}

		#endregion

		#region Инициализация

		public HorseUnitImprove(T unit) : base(unit)
		{ }

		#endregion

		#region Методы

		public override IUnit Clone()
		{
			var clonedUnit = (T)unit.Clone();
			var improvedClonedUnit = new HorseUnitImprove<T>(clonedUnit);

			return improvedClonedUnit;
		}

		public override void GetDamage(int damage)
		{
			if (horseHealth > 0)
			{
				horseHealth -= damage;
				if (horseHealth < 0)
				{
					base.GetDamage(Math.Abs(horseHealth));
					horseHealth = 0;
				}
			}
			else
			{
				base.GetDamage(damage);
			}
		}

		public override string ToString()
		{
			return $"{ base.ToString() } |лошадь { horseHealth }|";
		}

		#endregion
	}
}
