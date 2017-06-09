namespace StackGame.Units.Improvements
{
    /// <summary>
    /// Интерфейс улучшения единицы армии
    /// </summary>
    public interface IUnitImprove
    {
        #region Свойства

        /// <summary>
        /// Базовая единица армии
        /// </summary>
        IUnit Unit { get; }

        #endregion
    }
}
