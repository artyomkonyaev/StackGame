using StackGame.Core.Configs;

namespace StackGame.Units.Creators
{
    /// <summary>
    /// Создатель священника
    /// </summary>
    public class ClericUnitCreator : IUnitCreator
    {
		#region Методы

		/// <summary>
		/// Создать священника
		/// </summary>
		public IUnit Create()
		{
            var parameters = Configs.Units[UnitType.ClericUnit];
			return new ClericUnit(parameters.Health, parameters.Defence, parameters.Strength, parameters.Range, parameters.Power, parameters.Chance);
		}

		#endregion
	}
}
