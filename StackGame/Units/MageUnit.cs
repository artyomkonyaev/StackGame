namespace StackGame.Units
{
    /// <summary>
    /// Маг
    /// </summary>
    public class MageUnit : Unit
    {
		#region Инициализация

		public MageUnit() : base(100, 5)
        { }

		#endregion

		#region Методы

		public override string ToString()
		{
			return $"Маг: { base.ToString() }";
		}

		#endregion
	}
}
