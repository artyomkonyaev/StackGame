using System;
using StackGame.Army;
using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Маг
    /// </summary>
    public class MageUnit : Unit, IHealable, ISpecialAbility
    {
		#region Свойства

		public int Range { get; protected set; }
        public int Power => 0;
		public int Chance { get; protected set; }

		#endregion

		#region Инициализация

		public MageUnit(int health, int defence, int strength, int range, int chance) : base(health, defence, strength)
		{
			Range = range;
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

		public void DoSpecialAction(IArmy targetArmy, int unitPosition)
		{
            var random = new Random();
            var chance = random.Next(100 / Chance) == 0;

            if (chance && targetArmy.Units[unitPosition] is IClonable clonableUnit)
            {
                var clonedUnit = clonableUnit.Clone();
                targetArmy.Units.Add(clonedUnit);
            }
		}

		public override string ToString()
		{
			return $"Маг: { base.ToString() }";
		}

		#endregion
	}
}
