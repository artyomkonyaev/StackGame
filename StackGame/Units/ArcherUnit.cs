namespace StackGame.Units
{
    /// <summary>
    /// Лучник
    /// </summary>
    public class ArcherUnit : Unit
    {
		#region Инициализация

		public ArcherUnit() : base(100, 10)
        { }

		#endregion

		#region Методы

		public override string ToString()
		{
			return $"Лучник: { base.ToString() }";
		}

		#endregion
    }
}
