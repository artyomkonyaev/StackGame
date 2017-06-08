using System;

namespace StackGame.Observers
{
    /// <summary>
    /// Наблюдатель, издающий гудок при событии
    /// </summary>
    public class BeepObserver : IObserver
    {
		#region Методы

		/// <summary>
		/// Метод, вызываемый для уведомления наблюдателя
		/// </summary>
		public void Update(object @object)
        {
            Console.Beep();
        }

		#endregion
	}
}
