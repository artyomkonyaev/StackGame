using System;

namespace StackGame.Units
{
    /// <summary>
    /// Тяжелый пехотинец
    /// </summary>
    public class HeavyUnit : Unit
    {
		#region Свойства
		
        public override int Defense { get; protected set; } = 100;

		#endregion

		#region Инициализация

		public HeavyUnit() : base(50, 100, 10)
        { }

		#endregion

		#region Методы

		public override void GetDamage(int damage)
		{
            if (Defense > 0)
            {
                Defense -= damage;
                if (Defense < 0) {
                    base.GetDamage(Math.Abs(Defense));
                    Defense = 0;
                }
            }
            else 
            {
                base.GetDamage(damage);
            }
		}

		public override string ToString()
		{
			return $"Тяжелый пехотинец: { base.ToString() }";
		}

		#endregion
	}
}
