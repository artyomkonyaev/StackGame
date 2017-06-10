namespace StackGame.Helpers
{
    /// <summary>
    /// Генератор случайных чисел
    /// </summary>
    public static class Random
    {
        #region Свойства

        private static readonly System.Random random = new System.Random();

        #endregion

        #region Методы

        /// <summary>
        /// Вернуть не отрицательное целое число
        /// </summary>
        public static int Next()
        {
            return random.Next();
        }

        /// <summary>
        /// Вернять не отрицательное целое число, меньше указанного значение
        /// </summary>
        public static int Next(int maxValue)
        {
            return random.Next(maxValue);
        }

        #endregion
    }
}
