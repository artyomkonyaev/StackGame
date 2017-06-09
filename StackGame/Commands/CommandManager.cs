using System.Collections.Generic;
using StackGame.Loggers;

namespace StackGame.Commands
{
    /// <summary>
    /// Менеджер команд
    /// </summary>
    public class CommandManager
    {
        #region Свойства

        /// <summary>
        /// Возможно ли отменить ход
        /// </summary>
        public bool CanUndo => !undoStack.IsEmpty();
        /// <summary>
        /// Возможно ли повторить ход
        /// </summary>
        public bool CanRedo => !redoStack.IsEmpty();

        /// <summary>
        /// Стек команд для отмены
        /// </summary>
        private readonly Stack<ICommand> undoStack = new Stack<ICommand>();
        /// <summary>
        /// Стек команд для повтора
        /// </summary>
        private readonly Stack<ICommand> redoStack = new Stack<ICommand>();

        /// <summary>
        /// Журнал
        /// </summary>
        private readonly ILogger logger;

		#endregion

		#region Инициализация

        public CommandManager(ILogger logger)
        {
            this.logger = logger;
        }

		#endregion

		#region Методы

		/// <summary>
		/// Выполнить команду
		/// </summary>
		/// <returns>The execute.</returns>
		/// <param name="command">Command.</param>
		public void Execute(ICommand command)
        {
            command.Execute(logger);
            undoStack.Push(command);
        }

        /// <summary>
        /// Конец хода
        /// </summary>
        public void EndTurn()
        {
            var emptyCommand = new EmptyCommand();
            undoStack.Push(emptyCommand);

            CleanRedoCommands();
        }

        /// <summary>
        /// Отменить последний ход
        /// </summary>
        public void Undo()
        {
            var emptyCommand = undoStack.Pop();

            while (CanUndo && undoStack.Peek().GetType() != typeof(EmptyCommand))
            {
				var command = undoStack.Pop();
                redoStack.Push(command);

                command.Undo(logger);
            }

            redoStack.Push(emptyCommand);
        }

        /// <summary>
        /// Повторить последний ход
        /// </summary>
        public void Redo()
        {
            var emptyCommand = redoStack.Pop();

            while (CanRedo && redoStack.Peek().GetType() != typeof(EmptyCommand))
            {
				var command = redoStack.Pop();
				undoStack.Push(command);

                command.Execute(logger);
            }

            undoStack.Push(emptyCommand);
        }

        /// <summary>
        /// Очистить стек команд для повтора
        /// </summary>
        public void CleanRedoCommands()
        {
            redoStack.Clear();
        }

		#endregion
    }
}
