namespace StackGame.Commands
{
    /// <summary>
    /// Пустая команда
    /// </summary>
    public class EmptyCommand : ICommand
    {
        #region Методы

        public void Execute()
        { }

        public void Undo()
        { }

		#endregion
	}
}
