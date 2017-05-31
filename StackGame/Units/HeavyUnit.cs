using System;

namespace StackGame.Units
{
    /// <summary>
    /// Тяжелый пехотинец
    /// </summary>
    public class HeavyUnit : Unit
    {
		#region Свойства
		
        public override int Defence { get; protected set; } = 100;

		#endregion

		#region Инициализация

		public HeavyUnit() : base(100, 10)
        { }

		#endregion

		#region Методы

		public override void GetDamage(int damage)
		{
            if (Defence > 0)
            {
                Defence -= damage;
                if (Defence < 0) {
                    base.GetDamage(Math.Abs(Defence));
                    Defence = 0;
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
