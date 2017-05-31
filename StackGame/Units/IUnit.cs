namespace StackGame.Units
{
    /// <summary>
    /// Интерфейс единицы армии
    /// </summary>
	public interface IUnit
	{
		#region Свойства

		/// <summary>
		/// Стоимость
		/// </summary>
		int Cost { get; }

		/// <summary>
		/// Здоровье
		/// </summary>
		int Health { get; }
		/// <summary>
		/// Защита
		/// </summary>
		int Defense { get; }

		/// <summary>
		/// Сила
		/// </summary>
		int Strength { get; }

		#endregion

		#region Методы

		/// <summary>
		/// Получить урон
		/// </summary>
		void GetDamage(int damage);

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
		string ToString();

		#endregion
	}
}
