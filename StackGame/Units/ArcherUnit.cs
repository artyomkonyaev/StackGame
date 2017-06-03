using System;
using System.Collections.Generic;
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

		public int Range { get; private set; }
        public int Power { get; private set; }
        public int Chance { get; private set; }
        public bool IsFriendly { get; private set; } = false;

		#endregion

		#region Инициализация

		public ArcherUnit(int health, int defence, int strength, int range, int power, int chance) : base(health, defence, strength)
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

        public void DoSpecialAction(IArmy targetArmy, IEnumerable<int> targetRange, int position)
		{
			var random = new Random();
			var chance = random.Next(100 / Chance) == 0;

			if (chance)
			{
                var targetUnits = new List<IUnit>();
                foreach (var index in targetRange)
                {
                    var unit = targetArmy.Units[index];
                    if (unit.IsAlive)
                    {
                        targetUnits.Add(unit);
                    }
                }

                if (targetUnits.Count == 0)
                {
                    return;
                }

                var targetUnit = targetUnits[random.Next(targetUnits.Count)];
                targetUnit.TakeDamage(Power);

                Console.WriteLine($"{ToString()} нанес {Power} {targetUnit.ToString()}");
			}
		}

		public override string ToString()
		{
			return $"Лучник: { base.ToString() }";
		}

		#endregion
    }
}
