using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Священник
    /// </summary>
    public class ClericUnit : Unit, IClonable
    {
		#region Инициализация

		public ClericUnit() : base(100, 5)
        { }

		#endregion

		#region Методы

		public IUnit Clone()
		{
			return (IUnit)MemberwiseClone();
		}

		public override string ToString()
		{
			return $"Священник: { base.ToString() }";
		}

		#endregion
	}
}
