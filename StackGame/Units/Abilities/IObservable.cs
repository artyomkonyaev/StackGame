using StackGame.Observers;

namespace StackGame.Units.Abilities
{
    /// <summary>
    /// Интерфейс наблюдемой единицы армии
    /// </summary>
    public interface IObservable
    {
		#region Методы

        /// <summary>
        /// Зарегистрировать наблюдателя
        /// </summary>
		void RegisterObserver(IObserver observer);
        /// <summary>
        /// Удалить наблюдателя
        /// </summary>
		void RemoveObserver(IObserver observer);
        /// <summary>
        /// Уведомить наблюдателя
        /// </summary>
        void NotifyObservers(object @object);

        #endregion
    }
}
