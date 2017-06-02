namespace StackGame.Units
{
    /// <summary>
    /// Стена
    /// </summary>
    public class WallUnit : Unit
    {
		#region Инициализация

		public WallUnit() : base(300, 0)
        { }

		#endregion

		#region Методы

		public override string ToString()
		{
			return $"Стена: { base.ToString() }";
		}

		#endregion
	}
}
