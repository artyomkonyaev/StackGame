namespace StackGame.Units.Abilities
{
    /// <summary>
    /// Интерфейс клонируемой единицы армии
    /// </summary>
    public interface IClonable
    {
        /// <summary>
        /// Клонировать
        /// </summary>
        IUnit Clone();
    }
}
