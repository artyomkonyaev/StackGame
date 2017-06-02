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
			return new ArcherUnit();
		}

		#endregion
	}
}
