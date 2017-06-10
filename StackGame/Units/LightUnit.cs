using System;
using System.Collections.Generic;
using System.Linq;
using StackGame.Core.Engine;
using StackGame.Core.Commands;
using StackGame.Army;
using StackGame.Units.Abilities;
using StackGame.Units.Improvements;

namespace StackGame.Units
{
    /// <summary>
    /// Легкий пехотинец
    /// </summary>
    public class LightUnit : Unit, IHealable, IClonable, ISpecialAbility
    {
		#region Свойства

		public int Range { get; protected set; }
        public int Power => 0;
		public int Chance { get; protected set; }
        public bool IsFriendly { get; private set; } = true;

		#endregion

		#region Инициализация

		public LightUnit(int health, int defence, int strength, int range, int chance) : base(health, defence, strength)
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

		public IUnit Clone()
		{
			var clonedUnit = (Unit)MemberwiseClone();
			clonedUnit.observers = observers.Select(observer => observer).ToList();

			return clonedUnit;
		}

		public void DoSpecialAction(IArmy targetArmy, IEnumerable<int> targetRange, int position)
		{
			var chance = Helpers.Random.Next(100 / Chance) == 0;

			if (chance)
			{
				var targetUnits = new List<Tuple<int, IImprovable>>();
				foreach (var index in targetRange)
				{
                    if (index == position)
                    {
                        continue;
                    }

                    var unit = targetArmy.Units[index];
                    if (unit.IsAlive && unit is IClonable && unit is IImprovable improvableUnit)
					{
						targetUnits.Add(new Tuple<int, IImprovable>(index, improvableUnit));
					}
				}

				if (targetUnits.IsEmpty())
				{
					return;
				}

				var targetRow = targetUnits[Helpers.Random.Next(targetUnits.Count)];
                var targetIndex = targetRow.Item1;
                var targetUnit = targetRow.Item2;

				var unitImproveType = typeof(UnitImprove<>);
				var types = unitImproveType.Assembly.GetTypes().Where(type => type.BaseType != null && type.BaseType.IsGenericType).Where(type => type.BaseType.GetGenericTypeDefinition() == unitImproveType).ToList();

				do
				{
					var type = types[Helpers.Random.Next(types.Count)];
					if (targetUnit.CanImprove(type))
					{
						var unitImprove = type.MakeGenericType(targetUnit.GetType());

                        var command = new ImproveCommand(this, (IUnit)targetUnit, targetArmy, targetIndex, unitImprove);
						Engine.GetInstance().CommandManager.Execute(command);

						break;
					}

					types.Remove(type);
                } while (!types.IsEmpty());
			}
		}

        public override string ToString()
        {
            return $"Легкий пехотинец { base.ToString() }";
        }

		#endregion
	}
}
