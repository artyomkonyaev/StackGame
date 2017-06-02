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

		public int Range { get; } = 3;
		public int Power { get; } = 0;

		#endregion

		#region Инициализация

		public MageUnit() : base(100, 5)
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

		public void DoSpecialAction(IArmy targetArmy, IUnit targetUnit)
		{
            var random = new Random(DateTime.Now.Millisecond);
            var chance = random.Next(100 / 50) == 0;

            if (chance && targetUnit is IClonable clonableUnit)
            {
                var unit = clonableUnit.Clone();
                targetArmy.Units.Add(unit);
            }
		}

		public override string ToString()
		{
			return $"Маг: { base.ToString() }";
		}

		#endregion
	}
}
