namespace StackGame.Core.Configs
{
    /// <summary>
    /// Параметры единицы армии
    /// </summary>
    public struct UnitParameters
    {
        /// <summary>
        /// Цена
        /// </summary>
        public int Price;

        /// <summary>
        /// Здоровье
        /// </summary>
        public int Health;
        /// <summary>
        /// Защита
        /// </summary>
        public int Defence;
        /// <summary>
        /// Сила
        /// </summary>
        public int Strength;

        /// <summary>
        /// Дальность действия специальных возможностей
        /// </summary>
        public int Range;
        /// <summary>
        /// Мощность специальных возможностей
        /// </summary>
        public int Power;
        /// <summary>
        /// Вероятность воспользоваться специальной возможностью
        /// </summary>
        public int Chance;
    }
}
