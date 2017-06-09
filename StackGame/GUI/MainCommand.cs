namespace StackGame.GUI
{
    /// <summary>
    /// Команды основного меню
    /// </summary>
    public enum MainCommand
    {
        /// <summary>
        /// Новая игра
        /// </summary>
        NewGame = 1,
        /// <summary>
        /// Сделать ход
        /// </summary>
        NextTurn,
        /// <summary>
        /// Игра до победы
        /// </summary>
        PlayToEnd,
        /// <summary>
        /// Показать армии
        /// </summary>
        PrintArmies,
        /// <summary>
        /// Выбрать стратегию
        /// </summary>
        SelectStrategy,
        /// <summary>
        /// Ход назад
        /// </summary>
        Undo,
        /// <summary>
        /// Ход вперед
        /// </summary>
        Redo,
        /// <summary>
        /// Выход
        /// </summary>
        Exit
    }
}
