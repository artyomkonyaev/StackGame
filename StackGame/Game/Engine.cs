namespace StackGame.Game
{
    /// <summary>
    /// Движок игры
    /// </summary>
    public class Engine
    {
        #region Свойства

        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static Engine instance;

		#endregion

		#region Инициализация

		private Engine()
        { }

		#endregion

		#region Методы

        /// <summary>
        /// Получить экземпляр класса
        /// </summary>
        public static Engine GetInstance()
        {
            if (instance == null)
            {
                instance = new Engine();
            }

            return instance;
        }

		#endregion
	}
}
