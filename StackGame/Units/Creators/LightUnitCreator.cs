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
            return new LightUnit();
        }

		#endregion
	}
}
