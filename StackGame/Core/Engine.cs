using System;
using System.Collections.Generic;
using System.Linq;
using StackGame.Army;
using StackGame.Units;
using StackGame.Units.Abilities;

namespace StackGame.Core
{
	/// <summary>
    /// Движок игры
    /// </summary>
    public class Engine
    {
        #region Свойства

        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static Engine instance;

        /// <summary>
        /// Первая армия
        /// </summary>
        private IArmy firstArmy { get; set; }
        /// <summary>
        /// Вторая армия
        /// </summary>
        private IArmy secondArmy { get; set; }

        #endregion

        #region Инициализация

        private Engine()
        {
            firstArmy = new Army.Army("Белая");
            secondArmy = new Army.Army("Черная");
        }

        #endregion

        #region Методы

        /// <summary>
        /// Получить экземпляр класса
        /// </summary>
        public static Engine GetInstance()
        {
            if (instance == null)
            {
                instance = new Engine();
            }

            return instance;
        }

        /// <summary>
        /// Следующий ход
        /// </summary>
        public bool NextStep() {
            if (firstArmy.IsAllDead || secondArmy.IsAllDead) 
            {
                return false;
            }

            Console.WriteLine("Состояние \"до\":");
            Console.WriteLine(firstArmy.ToString());
            Console.WriteLine(secondArmy.ToString());

            // Создаем массив противников
            var _opponents = new Opponents(firstArmy.Units[0], secondArmy.Units[0]);
            var queue = new List<Opponents>
            {
                _opponents,
                _opponents.Reverse()
            };

            var random = new Random();
            queue = queue.OrderBy(opponents => random.Next()).ToList();

            // Бой
            foreach (var opponents in queue)
            {
                Hit(opponents.FirstArmyUnit, opponents.SecondArmyUnit);
            }

            var tmpCount = firstArmy.Units.Count;
            for (int i = 0; i < tmpCount; i++)
            {
                var unit = firstArmy.Units[i];
				if (unit.IsAlive && unit is ISpecialAbility specialUnit)
				{
                    var isFirst = i == 0;
                    if (isFirst)
                    {
                        continue;
                    }

                    var targetArmy = specialUnit.IsFriendly ? firstArmy : secondArmy;
                    var radius = specialUnit.Range;

                    int startIndex;
                    int endIndex;

                    if (specialUnit.IsFriendly)
                    {
						startIndex = i - radius;
						if (startIndex < 0)
						{
							startIndex = 0;
						}

						endIndex = i + radius;
                    }
                    else
                    {
                        if (i - radius >= 0)
                        {
                            continue;
                        }

                        startIndex = 0;
                        endIndex = Math.Abs(i - radius) - 1;
                    }

					if (endIndex >= targetArmy.Units.Count)
					{
						endIndex = targetArmy.Units.Count - 1;
					}

                    var count = endIndex - startIndex + 1;

                    if (count == 0)
                    {
                        continue;
                    }

                    Console.WriteLine($"unit {unit.ToString()} стартовый индекс {startIndex} количество {count}");

                    var range = Enumerable.Range(startIndex, count);

                    specialUnit.DoSpecialAction(targetArmy, range, i);
				}
            }

            // Удаление убитых
            RemoveDeadUnits(firstArmy);
            RemoveDeadUnits(secondArmy);

            Console.WriteLine();
			Console.WriteLine("Состояние \"после\":");
			Console.WriteLine(firstArmy.ToString());
			Console.WriteLine(secondArmy.ToString());

            return true;
        }

        /// <summary>
        /// Атаковать противника
        /// </summary>
        private void Hit(IUnit first, IUnit second)
        {
            if (first.IsAlive)
            {
                second.TakeDamage(first.Strength);
            }
        }

        /// <summary>
        /// Удалить мертвые единицы армии
        /// </summary>
        private void RemoveDeadUnits(IArmy army)
        {
            var dead = army.Units.Where(unit => !unit.IsAlive).ToList();
            foreach (var unitToBeDeleted in dead)
            {
                army.Units.Remove(unitToBeDeleted);
            }
        }

		#endregion
	}
}
