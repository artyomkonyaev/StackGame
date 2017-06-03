using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Лучник
    /// </summary>
    public class ArcherUnit : Unit, IHealable, IClonable, ISpecialAbility
    {
		#region Свойства

		public int Range => 3;
        public int Power => 15;

		#endregion

		#region Инициализация

		public ArcherUnit() : base(100, 10)
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

        public void DoSpecialAction(IArmy targetArmy, int unitPosition)
        {
            targetArmy.Units[unitPosition].TakeDamage(Power);
        }

		public override string ToString()
		{
			return $"Лучник: { base.ToString() }";
		}

		#endregion
    }
}
