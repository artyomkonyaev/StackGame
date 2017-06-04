﻿using System;
using System.Collections.Generic;
using System.Linq;
using StackGame.Strategy;
using StackGame.Army;
using StackGame.Units;
using StackGame.Units.Abilities;

namespace StackGame.Core.Engine
{
	/// <summary>
    /// Движок игры
    /// </summary>
    public class Engine
    {
        #region Свойства

        /// <summary>
        /// Стратегия боя
        /// </summary>
        public static IStrategy Strategy;

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
            Strategy = new StrategyAllVsAll();
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

            MeleeAttack();
            Console.WriteLine();
            SpecialAbilityAttack();
            Console.WriteLine();

            // Удаление убитых
            RemoveDeadUnits(firstArmy);
            RemoveDeadUnits(secondArmy);

			Console.WriteLine("Состояние \"после\":");
			Console.WriteLine(firstArmy.ToString());
			Console.WriteLine(secondArmy.ToString());

            return true;
        }

        /// <summary>
        /// Рукопашная атака
        /// </summary>
        private void MeleeAttack()
        {
            var queue = Strategy.GetOpponentsQueue(firstArmy, secondArmy);
			foreach (var opponents in queue)
			{
				Hit(opponents.Unit, opponents.EnemyUnit);
			}
        }

		/// <summary>
		/// Атаковать противника
		/// </summary>
		private void Hit(IUnit unit, IUnit enemyUnit)
		{
			if (unit.IsAlive && unit.Strength > 0 && enemyUnit.IsAlive)
			{
				enemyUnit.TakeDamage(unit.Strength);
                Console.WriteLine($"\ud83d\udde1 #{unit.ToString()}# нанес {unit.Strength} урона #{enemyUnit}#");
			}
		}

        /// <summary>
        /// Атака с применением специальных возможностей
        /// </summary>
        private void SpecialAbilityAttack()
        {
            var firstArmyUnitsCount = firstArmy.Units.Count;
            var firstArmyUnitIndex = 0;

            var secondArmyUnitsCount = secondArmy.Units.Count;
            var secondArmyUnitIndex = 0;

            while (firstArmyUnitIndex < firstArmyUnitsCount || secondArmyUnitIndex < secondArmyUnitsCount)
            {
                var _components = new List<SpecialAbilityComponents>();

                var firstArmyComponents = TryGetSpecialAbilityComponents(firstArmy, secondArmy, firstArmyUnitsCount, ref firstArmyUnitIndex);
                if (firstArmyComponents.HasValue)
                {
                    var specialAbilityComponents = firstArmyComponents.Value;
                    _components.Add(specialAbilityComponents);
                }

				var secondArmyComponents = TryGetSpecialAbilityComponents(secondArmy, firstArmy, secondArmyUnitsCount, ref secondArmyUnitIndex);
				if (secondArmyComponents.HasValue)
				{
					var specialAbilityComponents = secondArmyComponents.Value;
					_components.Add(specialAbilityComponents);
				}

                if (_components.Count == 0)
                {
                    continue;
                }

                _components = _components.Randomize().ToList();
                foreach (var components in _components)
                {
                    Console.WriteLine($"\ud83d\udd75️ #{components.Unit.ToString()}# проверяет с {components.Range.First()} индекса {components.Range.Count()} unit");
                    components.Unit.DoSpecialAction(components.Army, components.Range, components.Position);
                }
            }
        }

        /// <summary>
        /// Пытаемся получить компоненты для применения специальных возможностей
        /// </summary>
        SpecialAbilityComponents? TryGetSpecialAbilityComponents(IArmy army, IArmy enemyArmy, int armyUnitsCount, ref int armyUnitIndex)
        {
            if (armyUnitIndex < armyUnitsCount)
            {
                var tmpArmyUnitIndex = armyUnitIndex;
                armyUnitIndex++;

				var specialUnit = TryGetSpecialAbilityUnit(army, tmpArmyUnitIndex);
                if (specialUnit != null)
                {
                    var targetArmy = specialUnit.IsFriendly ? army : enemyArmy;

					var range = Strategy.GetUnitsRangeForSpecialAbility(targetArmy, specialUnit, tmpArmyUnitIndex);
					if (range != null)
					{
						var components = new SpecialAbilityComponents(specialUnit, targetArmy, range, tmpArmyUnitIndex);
						return components;
					}
                }
            }

            return null;
        }

        /// <summary>
        /// Пытаемся получить единицу армии, обладающую специальными возможностями
        /// </summary>
        ISpecialAbility TryGetSpecialAbilityUnit(IArmy army, int unitPosition)
        {
            var unit = army.Units[unitPosition];
            if (unit.IsAlive && unit is ISpecialAbility specialUnit)
            {
                return specialUnit;
            }

            return null;
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
