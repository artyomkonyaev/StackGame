namespace StackGame.Units
{
    /// <summary>
    /// Интерфейс единицы армии
    /// </summary>
	public interface IUnit
	{
		#region Свойства

		/// <summary>
		/// Здоровье
		/// </summary>
        int Health { get; set; }
		/// <summary>
		/// Максимальное здоровье
		/// </summary>
		int MaxHealth { get; }
		/// <summary>
		/// Защита
		/// </summary>
        int Defence { get; }

		/// <summary>
		/// Сила
		/// </summary>
		int Strength { get; }

        /// <summary>
        /// Есть ли еще здоровье
        /// </summary>
        bool IsAlive { get; }
        /// <summary>
        /// Поврежден ли
        /// </summary>
        bool IsDamaged { get; }

		#endregion

		#region Методы

        /// <summary>
        /// Получить урон
        /// </summary>
        void TakeDamage(int damage);

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
		string ToString();

		#endregion
	}
}
