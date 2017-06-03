using StackGame.Core.Configs;

namespace StackGame.Units.Creators
{
    /// <summary>
    /// Создатель лучника
    /// </summary>
    public class ArcherUnitCreator : IUnitCreator
    {
		#region Методы

		/// <summary>
		/// Создать лучника
		/// </summary>
		public IUnit Create()
		{
            var parameters = Configs.Units[UnitType.ArcherUnit];
            return new ArcherUnit(parameters.Health, parameters.Defence, parameters.Strength, parameters.Range, parameters.Power, parameters.Chance);
		}

		#endregion
	}
}
