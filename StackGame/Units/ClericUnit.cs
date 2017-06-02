using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Священник
    /// </summary>
    public class ClericUnit : Unit, IHealable, IClonable
    {
		#region Инициализация

		public ClericUnit() : base(100, 5)
        { }

		#endregion

		#region Методы

		public void Heal(int healthPower)
		{
			Health += healthPower;
			if (Health > MaxHealth)
			{
				Health = MaxHealth;
			}
		}

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
