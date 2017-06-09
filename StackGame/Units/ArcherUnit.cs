using System;
using System.Collections.Generic;
using System.Linq;
using StackGame.Core.Engine;
using StackGame.Commands;
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
		}

		public IUnit Clone()
        {
            var clonedUnit = (Unit)MemberwiseClone();
            clonedUnit.observers = observers.Select(observer => observer).ToList();

            return clonedUnit;
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

                if (targetUnits.IsEmpty())
                {
                    return;
                }

                var targetUnit = targetUnits[random.Next(targetUnits.Count)];

                var command = new HitCommand(this, targetUnit, Power);
                Engine.GetInstance().CommandManager.Execute(command);
			}
		}

		public override string ToString()
		{
			return $"Лучник: { base.ToString() }";
		}

		#endregion
    }
}
