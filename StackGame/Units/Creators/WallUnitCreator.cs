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
			return new WallUnit();
		}

		#endregion
	}
}
