namespace StackGame.Commands
{
    /// <summary>
    /// Интерфейс команды
    /// </summary>
    public interface ICommand
    {
		#region Методы

		/// <summary>
		/// Выполнить команду
		/// </summary>
		void Execute();
		/// <summary>
		/// Отменить результат выполнения команды
		/// </summary>
		void Undo();

		#endregion
    }
}
