namespace StackGame.Units.Abilities
{
    /// <summary>
    /// Интерфейс излечаемой единицы армии
    /// </summary>
    public interface IHealable
    {
		#region Методы

		/// <summary>
		/// Вылечить
		/// </summary>
		void Heal(int healthPower);

		#endregion
	}
}
