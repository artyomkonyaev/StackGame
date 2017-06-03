using System;
using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Тяжелый пехотинец
    /// </summary>
    public class HeavyUnit : Unit, IImprovable, IClonable
    {
		#region Инициализация

		public HeavyUnit(int health, int defence, int strength) : base(health, defence, strength)
        { }

		#endregion

		#region Методы

        public bool CanImprove(Type type)
        {
            return true;
        }

		public IUnit Clone()
		{
			return (IUnit)MemberwiseClone();
		}

		public override string ToString()
		{
			return $"Тяжелый пехотинец: { base.ToString() }";
		}

		#endregion
	}
}
