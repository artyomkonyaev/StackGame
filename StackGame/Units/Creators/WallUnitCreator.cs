using StackGame.Core.Configs;

namespace StackGame.Units.Creators
{
    /// <summary>
    /// Создатель стены
    /// </summary>
    public class WallUnitCreator : IUnitCreator
    {
		#region Методы

		/// <summary>
		/// Создать стену
		/// </summary>
		public IUnit Create()
		{
            var parameters = Configs.Units[UnitType.WallUnit];
            return new WallUnit(parameters.Health, parameters.Defence, parameters.Price);
		}

		#endregion
	}
}
