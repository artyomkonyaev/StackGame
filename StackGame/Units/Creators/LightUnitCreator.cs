using StackGame.Core.Configs;

namespace StackGame.Units.Creators
{
    /// <summary>
    /// Создатель легкого пехотинца
    /// </summary>
    public class LightUnitCreator : IUnitCreator
    {
		#region Методы

		/// <summary>
		/// Создать легкого пехотинца
		/// </summary>
        public IUnit Create()
        {
            var parameters = Configs.Units[UnitType.LightUnit];
			return new LightUnit(parameters.Health, parameters.Defence, parameters.Strength, parameters.Range, parameters.Chance);
        }

		#endregion
	}
}
