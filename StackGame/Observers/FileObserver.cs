using System;
using System.IO;
using System.Text;

namespace StackGame.Observers
{
    /// <summary>
    /// Наблюдатель, делающий запись в файл при событии
    /// </summary>
    public class FileObserver : IObserver
    {
		#region Свойства

		/// <summary>
		/// Название файла
		/// </summary>
		private readonly string fileName = "DeadLog.txt";
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private readonly string filePath;

		#endregion

		#region Инициализация

		public FileObserver()
		{
            var pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            filePath = Path.Combine(pathToDesktop, fileName);

            using (StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.Default))
            {
                streamWriter.WriteLine(string.Empty);
            }
		}

		#endregion

		#region Методы

		/// <summary>
		/// Метод, вызываемый для уведомления наблюдателя
		/// </summary>
		public void Update(object @object)
		{
            if (@object is string message)
            {
				using (StreamWriter streamWriter = new StreamWriter(filePath, true, Encoding.Default))
				{
					streamWriter.WriteLine(message);
				}
            }
		}

		#endregion
	}
}
