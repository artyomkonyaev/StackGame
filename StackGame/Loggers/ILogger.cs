namespace StackGame.Loggers
{
    /// <summary>
    /// Интерфейс журнала
    /// </summary>
    public interface ILogger
    {
        #region Методы

        /// <summary>
        /// Сделать запись
        /// </summary>
        void Log(string message);

        #endregion
    }
}
