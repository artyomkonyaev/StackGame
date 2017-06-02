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
			return new MageUnit();
		}

		#endregion
	}
}
