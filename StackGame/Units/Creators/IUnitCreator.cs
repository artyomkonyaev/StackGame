namespace StackGame.Units.Creators
{
    /// <summary>
    /// Интерфейс создателя единицы армии
    /// </summary>
    public interface IUnitCreator
    {
        #region Методы

        /// <summary>
        /// Создать единицу армии
        /// </summary>
        IUnit Create();

        #endregion
	}
}
