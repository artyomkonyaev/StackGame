namespace StackGame.Units
{
    /// <summary>
    /// Священник
    /// </summary>
    public class ClericUnit : Unit
    {
		#region Инициализация

		public ClericUnit() : base(100, 5)
        { }

		#endregion

		#region Методы

		public override string ToString()
		{
			return $"Священник: { base.ToString() }";
		}

		#endregion
	}
}
