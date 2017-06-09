using System;

namespace StackGame.GUI
{
    public static class ConsoleGUI
    {
		#region Методы

        public static void PrintError(string message)
        {
            Console.WriteLine($"🚫 { message }");
        }

		/// <summary>
		/// Вывести основное меню
		/// </summary>
		public static void PrintMainMenu()
		{
			Console.WriteLine("Меню:");
			Console.WriteLine("1️⃣  Новая игра");
			Console.WriteLine("2️⃣  Сделать ход");
			Console.WriteLine("3️⃣  Игра до победы");
			Console.WriteLine("4️⃣  Показать армии");
			Console.WriteLine("5️⃣  Выбрать стратегию боя");
			Console.WriteLine("6️⃣  Ход назад");
            Console.WriteLine("7️⃣  Ход вперед");
			Console.WriteLine("8️⃣  Выход");
            Console.WriteLine();
		}

		/// <summary>
		/// Считать команду основного меню
		/// </summary>
		public static MainCommand ReadMainCommand()
		{
            MainCommand? command = null;

            var isSuccessful = false;
			do
			{
				Console.Write("Введите команду: ");

                if (int.TryParse(Console.ReadLine(), out int input) && Enum.IsDefined(typeof(MainCommand), input))
                {
                    command = (MainCommand)input;
                    isSuccessful = true;
                }
                else
                {
                    var message = "Команда не существует, попробуйте еще раз.";
                    PrintError(message);
                }

                Console.WriteLine();
            } while (!isSuccessful);
			
            return command.Value;
		}

		/// <summary>
		/// Вывести меню выбора стратегии
		/// </summary>
		public static void PrintSelectStrategyMenu()
		{
			Console.WriteLine("Выберите стратегию боя:");
			Console.WriteLine("1️⃣  1 на 1");
			Console.WriteLine("2️⃣  N на N");
			Console.WriteLine("3️⃣  Все на всех");
            Console.WriteLine("4️⃣  Отмена");
			Console.WriteLine();
		}

		/// <summary>
		/// Считать команду меню выбора стратегии
		/// </summary>
		public static SelectStrategyCommand ReadSelectStrategyCommand()
		{
			SelectStrategyCommand? command = null;

			var isSuccessful = false;
			do
			{
				Console.Write("Введите команду: ");

				if (int.TryParse(Console.ReadLine(), out int input) && Enum.IsDefined(typeof(SelectStrategyCommand), input))
				{
					command = (SelectStrategyCommand)input;
					isSuccessful = true;
				}
				else
				{
					var message = "Команда не существует, попробуйте еще раз.";
					PrintError(message);
				}

				Console.WriteLine();
			} while (!isSuccessful);

			return command.Value;
		}

        /// <summary>
        /// Считать стоимость армии
        /// </summary>
        public static int ReadArmyCost()
        {
			int? @value = null;

			var isSuccessful = false;
			do
			{
				Console.Write("Введите стоимость армии: ");

				if (int.TryParse(Console.ReadLine(), out int input) && input > 0)
				{
					@value = input;
					isSuccessful = true;
				}
				else
				{
					var message = "Недопустимое значение, попробуйте еще раз.";
					PrintError(message);
				}

				Console.WriteLine();
			} while (!isSuccessful);

			return @value.Value;
        }

        /// <summary>
        /// Считать N для стратегии "N на N"
        /// </summary>
        public static int ReadNForNVsNStrategy()
        {
            int? n = null;

			var isSuccessful = false;
			do
			{
				Console.Write("Введите N: ");

				if (int.TryParse(Console.ReadLine(), out int input) && input > 1)
				{
					n = input;
					isSuccessful = true;
				}
				else
				{
                    var message = "Недопустимое значение, попробуйте еще раз.";
					PrintError(message);
				}

				Console.WriteLine();
			} while (!isSuccessful);

            return n.Value;
        }

        #endregion
    }
}
