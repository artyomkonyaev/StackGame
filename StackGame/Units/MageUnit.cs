using System;
using System.Collections.Generic;
using StackGame.Core.Engine;
using StackGame.Commands;
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
        public bool IsFriendly { get; private set; } = true;

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
		}

		public void DoSpecialAction(IArmy targetArmy, IEnumerable<int> targetRange, int position)
		{
			var random = new Random();
			var chance = random.Next(100 / Chance) == 0;

			if (chance)
			{
				var targetUnits = new List<IClonable>();
				foreach (var index in targetRange)
				{
					if (index == position)
					{
						continue;
					}

                    var unit = targetArmy.Units[index];
                    if (unit.IsAlive && unit is IClonable clonableUnit)
					{
						targetUnits.Add(clonableUnit);
					}
				}

                if (targetUnits.IsEmpty())
				{
					return;
				}

				var targetUnit = targetUnits[random.Next(targetUnits.Count)];

				var command = new CloneCommand(this, targetUnit, targetArmy);
				Engine.GetInstance().CommandManager.Execute(command);
			}
		}

		public override string ToString()
		{
			return $"Маг { base.ToString() }";
		}

		#endregion
	}
}
