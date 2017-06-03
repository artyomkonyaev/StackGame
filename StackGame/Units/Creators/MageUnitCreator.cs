using StackGame.Core.Configs;

namespace StackGame.Units.Creators
{
    /// <summary>
    /// Создатель мага
    /// </summary>
    public class MageUnitCreator : IUnitCreator
    {
		#region Методы

		/// <summary>
		/// Создать мага
		/// </summary>
		public IUnit Create()
		{
            var parameters = Configs.Units[UnitType.MageUnit];
			return new MageUnit(parameters.Health, parameters.Defence, parameters.Strength, parameters.Range, parameters.Chance);
		}

		#endregion
	}
}
