using StackGame.Loggers;
using StackGame.Core.Engine;
using StackGame.Strategy;

namespace StackGame.Commands
{
    /// <summary>
    /// Команда "изменить стратегию"
    /// </summary>
    public class ChangeStrategyCommand : ICommand
    {
		#region Свойства

		/// <summary>
		/// Исходная стратегия
		/// </summary>
        private readonly IStrategy sourceStrategy;
		/// <summary>
		/// Стратегия
		/// </summary>
		private readonly IStrategy strategy;
		/// <summary>
		/// Количество шагов без смертей
		/// </summary>
		private readonly int countTurnsWithoutDeath;

		#endregion

		#region Инициализация

		public ChangeStrategyCommand(IStrategy sourceStrategy, IStrategy strategy, int countTurnsWithoutDeath)
		{
			this.sourceStrategy = sourceStrategy;
			this.strategy = strategy;
            this.countTurnsWithoutDeath = countTurnsWithoutDeath;
		}

		#endregion

		#region Методы

		public void Execute(ILogger logger)
		{
            Engine.GetInstance().Strategy = strategy;
            Engine.GetInstance().CountTurnsWithoutDeath = 0;

			var message = "📌 Стратегия изменена";
			logger.Log(message);
		}

		public void Undo(ILogger logger)
		{
			Engine.GetInstance().Strategy = sourceStrategy;
            Engine.GetInstance().CountTurnsWithoutDeath = countTurnsWithoutDeath;
		}

		#endregion
	}
}
