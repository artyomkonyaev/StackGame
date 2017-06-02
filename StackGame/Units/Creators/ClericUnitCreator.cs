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
			return new ClericUnit();
		}

		#endregion
	}
}
