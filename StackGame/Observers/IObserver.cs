namespace StackGame.Observers
{
    /// <summary>
    /// Интерфейс наблюдателя
    /// </summary>
    public interface IObserver
    {
        #region Методы

        /// <summary>
        /// Метод, вызываемый для уведомления наблюдателя
        /// </summary>
        void Update(object @object);

        #endregion
    }
}
