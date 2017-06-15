using System;
using StackGame.GUI;
using StackGame.Core.Strategies;
using StackGame.Core.Engine;

namespace StackGame
{
    class MainClass
    {
        /// <summary>
        /// Вывести copyright
        /// </summary>
        public static void PrintCopyright()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine();
            Console.WriteLine("##############################");
            Console.WriteLine("#                            #");
            Console.WriteLine("#         Выполнил студент   #");
            Console.WriteLine("#   РЭУ им Г. В. Плеханова   #");
            Console.WriteLine("#          группы ДКО-142б   #");
            Console.WriteLine("#    Халяпин Илья Игоревич   #");
            Console.WriteLine("#                            #");
            Console.WriteLine("##############################");
            Console.WriteLine();

            Console.ResetColor();
        }

        public static void Main(string[] args)
        {
            PrintCopyright();

            var gameStarted = false;
                  
            MainCommand? command = null;
            do
            {
                ConsoleGUI.PrintMainMenu();
                command = ConsoleGUI.ReadMainCommand();

                if (!gameStarted && command != MainCommand.NewGame && command != MainCommand.Exit)
                {
                    var message = "Игра не запущена. Необходимо начать новую игру.";
					ConsoleGUI.PrintError(message);
                    Console.WriteLine();

                    continue;
                }
                if (gameStarted && command != MainCommand.NewGame && command != MainCommand.PrintArmies && command != MainCommand.Undo && command != MainCommand.Exit)
                {
					if (Engine.GetInstance().IsGameEnded)
					{
                        var message = "Игра закончена. Необходимо начать новую игру.";
						ConsoleGUI.PrintError(message);
						Console.WriteLine();

						continue;
					}
                }

                switch (command)
                {
                    case MainCommand.NewGame:
                        var armyCost = ConsoleGUI.ReadArmyCost();

						ConsoleGUI.PrintSelectStrategyMenu();
						var _selectStrategyCommand = ConsoleGUI.ReadSelectStrategyCommand();

						IStrategy _strategy = null;
						switch (_selectStrategyCommand)
						{
							case SelectStrategyCommand.Strategy1Vs1:
								_strategy = new Strategy1Vs1();

								break;
							case SelectStrategyCommand.StrategyNVsN:
								var n = ConsoleGUI.ReadNForNVsNStrategy();
								_strategy = new StrategyNVsN(n);

								break;
							case SelectStrategyCommand.StrategyAllVsAll:
								_strategy = new StrategyAllVsAll();

								break;
							case SelectStrategyCommand.Cancel:
								continue;
						}

                        Engine.GetInstance().NewGame(armyCost, _strategy);

						if (Engine.GetInstance().IsGameEnded)
						{
                            gameStarted = false;

							Console.WriteLine("Необходимо увеличить стоимость армии.");
							Console.WriteLine();
						}
                        else
                        {
							gameStarted = true;

							Console.WriteLine("Новая игра начата.");
							Console.WriteLine();

							Console.WriteLine(Engine.GetInstance().FirstArmy);
							Console.WriteLine(Engine.GetInstance().SecondArmy);
                        }

                        break;
                    case MainCommand.NextTurn:
                        if (!Engine.GetInstance().IsCanMakeNextStep)
                        {
							Console.WriteLine("⚠️  Необходимо изменить стратегию игры или начать новую игру.");
							Console.WriteLine();

                            continue;
                        }

                        Engine.GetInstance().NextStep();
                        Console.WriteLine();

                        if (Engine.GetInstance().IsGameEnded)
                        {
                            Console.WriteLine("Игра закончена.");
                            if (Engine.GetInstance().IsFirstArmyWin)
                            {
                                Console.WriteLine("Победила первая армия.");
                            }
                            else if (Engine.GetInstance().IsSecondArmyWin)
                            {
                                Console.WriteLine("Победила вторая армия.");   
                            }
                            Console.WriteLine();
                        }

                        break;
                    case MainCommand.PlayToEnd:
                        Engine.GetInstance().PlayToEnd();
                        Console.WriteLine();

                        if (Engine.GetInstance().IsGameEnded)
                        {
                            Console.WriteLine("Игра закончена.");
							if (Engine.GetInstance().IsFirstArmyWin)
							{
								Console.WriteLine("Победила первая армия.");
							}
							else if (Engine.GetInstance().IsSecondArmyWin)
							{
								Console.WriteLine("Победила вторая армия.");
							}
							Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("⚠️  Необходимо изменить стратегию игры или начать новую игру.");
                            Console.WriteLine();
                        }

                        break;
                    case MainCommand.PrintArmies:
						Console.WriteLine(Engine.GetInstance().FirstArmy);
						Console.WriteLine(Engine.GetInstance().SecondArmy);

                        break;
                    case MainCommand.SelectStrategy:
                        ConsoleGUI.PrintSelectStrategyMenu();
                        var selectStrategyCommand = ConsoleGUI.ReadSelectStrategyCommand();

                        IStrategy strategy = null;
                        switch (selectStrategyCommand)
                        {
                            case SelectStrategyCommand.Strategy1Vs1:
                                strategy = new Strategy1Vs1();

                                break;
                            case SelectStrategyCommand.StrategyNVsN:
                                var n = ConsoleGUI.ReadNForNVsNStrategy();
                                strategy = new StrategyNVsN(n);

                                break;
                            case SelectStrategyCommand.StrategyAllVsAll:
                                strategy = new StrategyAllVsAll();

                                break;
                            case SelectStrategyCommand.Cancel:
                                continue;
                        }

                        Engine.GetInstance().ChangeStrategy(strategy);
                        Console.WriteLine();

                        break;
                    case MainCommand.Undo:
                        if (!Engine.GetInstance().CommandManager.CanUndo)
                        {
                            var message = "Невозможно вернуться на ход назад.";
							ConsoleGUI.PrintError(message);
                            Console.WriteLine();

                            continue;
                        }

                        Engine.GetInstance().CommandManager.Undo();

                        Console.WriteLine("Выполнен ход назад.");
						Console.WriteLine();

                        break;
                    case MainCommand.Redo:
						if (!Engine.GetInstance().CommandManager.CanRedo)
						{
							var message = "Невозможно выполнить ход вперед.";
							ConsoleGUI.PrintError(message);
							Console.WriteLine();

							continue;
						}

						Engine.GetInstance().CommandManager.Redo();
                        Console.WriteLine();

						Console.WriteLine("Выполнен ход вперед.");
						Console.WriteLine();

                        break;
                    case MainCommand.Exit:
                        Console.WriteLine("Конец игры.");
                        Console.WriteLine();

                        break;
                }
            } while (command.Value != MainCommand.Exit);
        }
    }
}
