using System;
using System.Linq;
using StackGame.Units.Abilities;

namespace StackGame.Units
{
    /// <summary>
    /// Тяжелый пехотинец
    /// </summary>
    public class HeavyUnit : Unit, IImprovable, IClonable
    {
        #region

        /// <summary>
        /// Количество улучшений
        /// </summary>
        public int ImprovementsCount => 0;

        #endregion

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
			var clonedUnit = (Unit)MemberwiseClone();
			clonedUnit.observers = observers.Select(observer => observer).ToList();

			return clonedUnit;
		}

		public override string ToString()
		{
			return $"Тяжелый пехотинец { base.ToString() }";
		}

		#endregion
	}
}
