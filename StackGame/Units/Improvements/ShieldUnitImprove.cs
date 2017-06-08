using StackGame.Core.Configs;
using StackGame.Units.Abilities;

namespace StackGame.Units.Improvements
{
    /// <summary>
	/// Щит
	/// </summary>
	public class ShieldUnitImprove<T> : UnitImprove<T> where T : IUnit, IImprovable, IClonable
	{
        #region Свойства

        /// <summary>
        /// Защита щита
        /// </summary>
        private readonly int shieldDefence;

		public override int Defence => base.Defence + shieldDefence;

		#endregion

		#region Инициализация

		public ShieldUnitImprove(T unit) : base(unit)
		{
            var parameters = Configs.UnitImproves[UnitImproveType.Shield];
			shieldDefence = parameters.Defence;
        }

		#endregion

		#region Методы

		public override IUnit Clone()
		{
			var clonedUnit = (T)Unit.Clone();
			var improvedClonedUnit = new ShieldUnitImprove<T>(clonedUnit);

			return improvedClonedUnit;
		}

		public override string ToString()
		{
            return $"{ base.ToString() } |щит - защита { shieldDefence }|";
		}

		#endregion
	}
}
