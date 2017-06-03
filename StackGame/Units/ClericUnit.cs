using System;
using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Священник
    /// </summary>
    public class ClericUnit : Unit, IHealable, IClonable, ISpecialAbility
    {
		#region Свойства

		public int Range { get; private set; }
		public int Power { get; private set; }
		public int Chance { get; private set; }

		#endregion

		#region Инициализация

		public ClericUnit(int health, int defence, int strength, int range, int power, int chance) : base(health, defence, strength)
		{
			Range = range;
			Power = power;
			Chance = chance;
		}

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
			var random = new Random();
			var chance = random.Next(100 / Chance) == 0;

			if (chance && targetArmy.Units[unitPosition] is IHealable healableUnit)
			{
				healableUnit.Heal(Power);
			}
		}

		public override string ToString()
		{
			return $"Священник: { base.ToString() }";
		}

		#endregion
	}
}
