namespace StackGame.Units
{
    /// <summary>
    /// Легкий пехотинец
    /// </summary>
    public class LightUnit : Unit
    {
		#region Инициализация

		public LightUnit() : base(100, 15)
        { }

		#endregion

		#region Методы

        public override string ToString()
        {
            return $"Легкий пехотинец: { base.ToString() }";
        } 

		#endregion
	}
}
