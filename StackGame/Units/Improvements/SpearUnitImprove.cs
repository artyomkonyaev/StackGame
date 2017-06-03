using StackGame.Core.Configs;
using StackGame.Units.Abilities;

namespace StackGame.Units.Improvements
{
    /// <summary>
	/// Копье
	/// </summary>
	public class SpearUnitImprove<T> : UnitImprove<T> where T : IUnit, IImprovable, IClonable
	{
		#region Свойства

		/// <summary>
		/// Сила копья
		/// </summary>
		private int horseStrength;

		public override int Strength => base.Strength + horseStrength;

		#endregion

		#region Инициализация

		public SpearUnitImprove(T unit) : base(unit)
		{
            var parameters = Configs.UnitImproves[UnitImproveType.Spear];
            horseStrength = parameters.Strength;
        }

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
