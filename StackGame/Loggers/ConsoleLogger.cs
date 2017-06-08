using System;

namespace StackGame.Loggers
{
    /// <summary>
    /// Консольный журнал
    /// </summary>
    public class ConsoleLogger : ILogger
    {
		#region Методы

		/// <summary>
		/// Сделать запись
		/// </summary>
		public void Log(string message)
        {
            Console.WriteLine(message);
        }

		#endregion
	}
}
