using System;
using StackGame.Core;

namespace StackGame
{
    class MainClass
    {
        /// <summary>
        /// Вывести меню
        /// </summary>
        static void PrintMenu() 
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Начало игры");
            Console.WriteLine("2. Показать армию");
            Console.WriteLine("3. Сделать ход");
            Console.WriteLine("4. Ход назад");
            Console.WriteLine("5. Ход вперед");
            Console.WriteLine("6. Ходы до концы");
            Console.WriteLine("7. Выход");
        }

        /// <summary>
        /// Считать команду
        /// </summary>
        static int ReadCommand() 
        {
            int command = 0;
            do
            {
                Console.Write("Введите команду: ");
            } while (!Int32.TryParse(Console.ReadLine(), out command));

            return command;
        }

        public static void Main(string[] args)
        {
            int command = 0;
            do
            {
                PrintMenu();
                command = ReadCommand();

                switch (command)
                {
                    case 1:
                        Engine.GetInstance();
                        Console.WriteLine("Игра начата");

                        break;
                    case 3:
                        if (!Engine.GetInstance().NextStep())
                        {
                            Console.WriteLine("Конец игры");
                            command = 7;
                        }

                        break;
                    case 7:
                        break;

                    default:
                        Console.WriteLine("Команда не существует!");
                        break;
                        
                }
            } while (command != 7);
        }
    }
}
