using System;

namespace StackGame.Units.Abilities
{
    /// <summary>
    /// Интерфейс улучшаемой единицы армии
    /// </summary>
    public interface IImprovable
    {
        #region Свойства

        /// <summary>
        /// Количество улучшений
        /// </summary>
        int ImprovementsCount { get; }

		#endregion

		#region Методы

		/// <summary>
		/// Можно ли улучшить
		/// </summary>
		bool CanImprove(Type type);

		#endregion
	}
}
