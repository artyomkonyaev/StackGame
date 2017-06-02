using System;
using StackGame.Units.Abilities;

namespace StackGame.Units.Improvements
{
    /// <summary>
	/// Копье
	/// </summary>
	public class SpearUnitImprove<T> : UnitImprove<T> where T : IUnit, IImprovable, IClonable
	{
		#region Свойства

		public override int Strength
		{
			get
			{
				return base.Strength + 10;
			}
		}

		#endregion

		#region Инициализация

		public SpearUnitImprove(T unit) : base(unit)
		{ }

        #endregion

        #region Методы

        public override IUnit Clone()
        {
            var clonedUnit = (T)unit.Clone();
            var improvedClonedUnit = new SpearUnitImprove<T>(clonedUnit);

            return improvedClonedUnit;
        }

		public override string ToString()
		{
			return $"{ base.ToString() } |копье|";
		}

		#endregion
	}
}
