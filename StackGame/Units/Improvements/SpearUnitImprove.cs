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
		private readonly int spearStrength;

		public override int Strength => base.Strength + spearStrength;

		#endregion

		#region Инициализация

		public SpearUnitImprove(T unit) : base(unit)
		{
            var parameters = Configs.UnitImproves[UnitImproveType.Spear];
            spearStrength = parameters.Strength;
        }

        #endregion

        #region Методы

        public override IUnit Clone()
        {
            var clonedUnit = (T)Unit.Clone();
            var improvedClonedUnit = new SpearUnitImprove<T>(clonedUnit);

            return improvedClonedUnit;
        }

		public override string ToString()
		{
            return $"{ base.ToString() } |копье - атака { spearStrength }|";
		}

		#endregion
	}
}
