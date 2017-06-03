using StackGame.Core.Configs;

namespace StackGame.Units.Creators
{
	/// <summary>
	/// Создатель тяжелого пехотинца
	/// </summary>
	public class HeavyUnitCreator : IUnitCreator
	{
		#region Методы

		/// <summary>
		/// Создать тяжелого пехотинца
		/// </summary>
		public IUnit Create()
		{
            var parameters = Configs.Units[UnitType.HeavyUnit];
			return new HeavyUnit(parameters.Health, parameters.Defence, parameters.Strength);
		}

		#endregion
	}
}
