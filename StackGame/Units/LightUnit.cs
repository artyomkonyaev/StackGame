using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Легкий пехотинец
    /// </summary>
    public class LightUnit : Unit, IHealable, IClonable
    {
		#region Инициализация

		public LightUnit() : base(100, 15)
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
            return $"Легкий пехотинец: { base.ToString() }";
        }

		#endregion
	}
}
