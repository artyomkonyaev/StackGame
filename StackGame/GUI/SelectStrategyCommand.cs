namespace StackGame.GUI
{
    /// <summary>
    /// Команды меню выбора стратегии
    /// </summary>
    public enum SelectStrategyCommand
    {
		/// <summary>
		/// Стратегия "1 на 1"
		/// </summary>
		Strategy1Vs1 = 1,
		/// <summary>
		/// Стратегия "n на n"
		/// </summary>
		StrategyNVsN,
		/// <summary>
		/// Стратегия "все на всех"
		/// </summary>
		StrategyAllVsAll,
		/// <summary>
		/// Отмена
		/// </summary>
		Cancel
    }
}
