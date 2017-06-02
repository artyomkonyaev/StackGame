namespace StackGame.Units.Abilities
{
    /// <summary>
    /// Интерфейс клонируемой единицы армии
    /// </summary>
    public interface IClonable
    {
        #region Методы

        /// <summary>
        /// Клонировать
        /// </summary>
        IUnit Clone();

        #endregion
    }
}
