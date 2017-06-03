using System;
using System.Linq;
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

        public int Range => 1;
		public int Power => 0;

		#endregion

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

		public void DoSpecialAction(IArmy targetArmy, int unitPosition)
		{
			var random = new Random();
			var chance = random.Next(100 / 50) == 0;

            if (chance && targetArmy.Units[unitPosition] is IImprovable improvableUnit)
			{
                var unitImproveType = typeof(UnitImprove<>);
                var types = unitImproveType.Assembly.GetTypes().Where(type => type.BaseType != null && type.BaseType.IsGenericType).Where(type => type.BaseType.GetGenericTypeDefinition() == unitImproveType.GetGenericTypeDefinition()).ToList();

                do
                {
                    var type = types[random.Next(types.Count)];
                    if (improvableUnit.CanImprove(type)) 
                    {
                        var unitImprove = type.MakeGenericType(improvableUnit.GetType());
                        var improvementUnit = (IUnit)Activator.CreateInstance(unitImprove, improvableUnit);

                        targetArmy.Units[unitPosition] = improvementUnit;

                        break;
                    }

                    types.Remove(type);
                } while (types.Count != 0);
			}
		}

        public override string ToString()
        {
            return $"Легкий пехотинец: { base.ToString() }";
        }

		#endregion
	}
}
