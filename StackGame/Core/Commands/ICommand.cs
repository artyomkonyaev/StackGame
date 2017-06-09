using StackGame.Loggers;

namespace StackGame.Core.Commands
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
		void Execute(ILogger logger);
		/// <summary>
		/// Отменить результат выполнения команды
		/// </summary>
		void Undo(ILogger logger);

		#endregion
    }
}
