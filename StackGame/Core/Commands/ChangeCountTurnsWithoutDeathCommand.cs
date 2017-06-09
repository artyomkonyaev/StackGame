using StackGame.Loggers;

namespace StackGame.Core.Commands
{
    /// <summary>
    /// Команда "изменить количество шагов без смертей"
    /// </summary>
    public class ChangeCountTurnsWithoutDeathCommand : ICommand
    {
		#region Свойства

		/// <summary>
		/// Исходное количество шагов без смертей
		/// </summary>
		private readonly int sourceCountTurnsWithoutDeath;
        /// <summary>
		/// Количество шагов без смертей
		/// </summary>
		private readonly int countTurnsWithoutDeath;
		
		#endregion

		#region Инициализация

		public ChangeCountTurnsWithoutDeathCommand(int sourceCountTurnsWithoutDeath, int countTurnsWithoutDeath)
		{
            this.sourceCountTurnsWithoutDeath = sourceCountTurnsWithoutDeath;
			this.countTurnsWithoutDeath = countTurnsWithoutDeath;
		}

		#endregion

		#region Методы

		public void Execute(ILogger logger)
		{
            Engine.Engine.GetInstance().CountTurnsWithoutDeath = countTurnsWithoutDeath;
		}

		public void Undo(ILogger logger)
		{
			Engine.Engine.GetInstance().CountTurnsWithoutDeath = sourceCountTurnsWithoutDeath;
		}

		#endregion
	}
}
