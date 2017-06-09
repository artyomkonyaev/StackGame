using System;
using System.IO;
using System.Text;

namespace StackGame.Loggers
{
    /// <summary>
    /// Файловый журнал
    /// </summary>
    public class FileLogger : ILogger
    {
        #region Свойства

        /// <summary>
        /// Название файла
        /// </summary>
        private readonly string fileName;
		/// <summary>
		/// Путь к файлу
		/// </summary>
		private readonly string filePath;

        #endregion

        #region Инициализация

        public FileLogger(string fileName)
        {
            this.fileName = fileName;

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
        /// Сделать запись
        /// </summary>
        public void Log(string message)
		{
			using (StreamWriter streamWriter = new StreamWriter(filePath, true, Encoding.Default))
			{
				streamWriter.WriteLine(message);
			}
		}

		#endregion
	}
}
