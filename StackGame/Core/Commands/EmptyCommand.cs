using StackGame.Loggers;

namespace StackGame.Core.Commands
{
    /// <summary>
    /// Пустая команда
    /// </summary>
    public class EmptyCommand : ICommand
    {
        #region Методы

        public void Execute(ILogger logger)
        { }

        public void Undo(ILogger logger)
        { }

		#endregion
	}
}
