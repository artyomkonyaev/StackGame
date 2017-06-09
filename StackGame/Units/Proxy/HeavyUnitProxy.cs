using System;
using StackGame.Loggers;
using StackGame.Units.Abilities;

namespace StackGame.Units.Proxy
{
    /// <summary>
    /// Прокси тяжелого пехотинца
    /// </summary>
    public class HeavyUnitProxy : IUnit, IImprovable, IClonable
    {
        #region Свойства

        /// <summary>
        /// Тяжелый пехотинец
        /// </summary>
        private readonly HeavyUnit heavyUnit;

        /// <summary>
        /// Журнал
        /// </summary>
        private readonly ILogger logger;

		/// <summary>
		/// Здоровье
		/// </summary>
		public virtual int Health
        {
            get => heavyUnit.Health;
            set => heavyUnit.Health = value;
        }
        /// <summary>
        /// Максимальное здоровье
        /// </summary>
        public virtual int MaxHealth => heavyUnit.MaxHealth;
        /// <summary>
        /// Защита
        /// </summary>
        public virtual int Defence => heavyUnit.Defence;

        /// <summary>
        /// Сила
        /// </summary>
        public virtual int Strength => heavyUnit.Strength;

        /// <summary>
        /// Есть ли еще здоровье
        /// </summary>
        public virtual bool IsAlive => heavyUnit.IsAlive;
        /// <summary>
        /// Поврежден ли
        /// </summary>
        public bool IsDamaged => heavyUnit.IsDamaged;

		/// <summary>
		/// Количество улучшений
		/// </summary>
        public int ImprovementsCount => heavyUnit.ImprovementsCount;

		#endregion

		#region Инициализация

        public HeavyUnitProxy(HeavyUnit heavyUnit, ILogger logger)
		{
			this.heavyUnit = heavyUnit;
            this.logger = logger;
		}

		#endregion

		#region Методы

		/// <summary>
		/// Получить урон
		/// </summary>
		public void TakeDamage(int damage)
		{
            heavyUnit.TakeDamage(damage);

            var message = $"{ DateTime.Now }: \ud83d\udca2 #{ this }# получил урон { damage }";
            logger.Log(message);

            if (!IsAlive)
            {
				message = $"{ DateTime.Now }: ☠️ #{ this }# умер";
				logger.Log(message);
            }
		}

		public bool CanImprove(Type type)
		{
            return heavyUnit.CanImprove(type);
		}

		public IUnit Clone()
		{
            var clonedUnit = (HeavyUnit)heavyUnit.Clone();
            var clonedUnitProxy = new HeavyUnitProxy(clonedUnit, logger);

			var message = $"{ DateTime.Now }: \ud83d\uddff #{ this }# клонирован";
			logger.Log(message);

            return clonedUnitProxy;
		}

		/// <summary>
		/// Преобразовать в строку
		/// </summary>
		public override string ToString()
		{
            return heavyUnit.ToString();
		}

		#endregion
	}
}
