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
			return new HeavyUnit();
		}

		#endregion
	}
}
