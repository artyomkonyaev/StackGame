﻿using System;
using System.Collections.Generic;
using System.Linq;
using StackGame.Loggers;
using StackGame.Observers;
using StackGame.Commands;
using StackGame.Strategy;
using StackGame.Army;
using StackGame.Army.Factory;
using StackGame.Units;
using StackGame.Units.Abilities;
using StackGame.Units.Proxy;

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
        public IStrategy Strategy = new Strategy1Vs1();

        /// <summary>
        /// Менеджер команд
        /// </summary>
        public readonly CommandManager CommandManager;

        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static Engine instance;

        /// <summary>
        /// Первая армия
        /// </summary>
        private readonly IArmy firstArmy;
        /// <summary>
        /// Вторая армия
        /// </summary>
        private readonly IArmy secondArmy;

        #endregion

        #region Инициализация

        private Engine()
        {
            // Создание армий
            var factory = new RandomUnitsFactory();
            var armyCost = Configs.Configs.ArmyCost;

            firstArmy = new Army.Army("Белая", factory, armyCost);
            secondArmy = new Army.Army("Черная", factory, armyCost);

            // Добавление наблюдателей для единиц армий
            var observers = new List<IObserver>
            {
                new FileObserver(),
                new BeepObserver()
            };

            AddObservers(firstArmy, observers);
            AddObservers(secondArmy, observers);

            // Создание менеджера команд
            ILogger logger = new ConsoleLogger();
            CommandManager = new CommandManager(logger);

            // Замена тяжелых пехотинцев на прокси
            logger = new FileLogger("HeavyUnitProxyLog.txt");

            ReplaceHeavyUnitsWithProxy(firstArmy, logger);
            ReplaceHeavyUnitsWithProxy(secondArmy, logger);
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
        /// Добавить наблюдателей для армии
        /// </summary>
        private void AddObservers(IArmy army, List<IObserver> observers)
        {
			foreach (var unit in army.Units)
			{
				if (unit is IObservable observableUnit)
				{
					foreach (var observer in observers)
					{
                        observableUnit.RegisterObserver(observer);
					}
				}
			}
        }

        /// <summary>
        /// Заменить тяжелых пехотинцев на proxy
        /// </summary>
        private void ReplaceHeavyUnitsWithProxy(IArmy army, ILogger logger)
        {
            for (int i = 0; i < army.Units.Count; i++)
            {
                var unit = army.Units[i];
                if (unit is HeavyUnit heavyUnit)
                {
                    var heavyUnitProxy = new HeavyUnitProxy(heavyUnit, logger);
                    army.Units[i] = heavyUnitProxy;
                }
            }
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
            Console.WriteLine(firstArmy);
            Console.WriteLine(secondArmy);

            MeleeAttack();
            Console.WriteLine();
            SpecialAbilityAttack();
            Console.WriteLine();
            CollectDeadUnits();

			Console.WriteLine("Состояние \"после\":");
            Console.WriteLine(firstArmy);
			Console.WriteLine(secondArmy);

            CommandManager.EndTurn();

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
                Hit(opponents.Army, opponents.UnitPosition, opponents.EnemyArmy, opponents.EnemyUnitPosition);
			}
        }

		/// <summary>
		/// Атаковать противника
		/// </summary>
        private void Hit(IArmy army, int unitPosition, IArmy enemyArmy, int enemyUnitPosition)
		{
            var unit = army.Units[unitPosition];
            var enemyUnit = enemyArmy.Units[enemyUnitPosition];

			if (unit.IsAlive && unit.Strength > 0 && enemyUnit.IsAlive)
			{
                ICommand command = new HitCommand(unit, enemyUnit, unit.Strength);
				CommandManager.Execute(command);

                if (enemyUnit.IsAlive && enemyUnit is IImprovable improvableUnit && improvableUnit.ImprovementsCount > 0)
                {
                    var random = new Random();
                    if (random.Next(2) == 0)
                    {
						command = new RemoveImprovementCommand(improvableUnit, enemyArmy, enemyUnitPosition);
						CommandManager.Execute(command);
                    }
                }
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

                if (_components.IsEmpty())
                {
                    continue;
                }
                if (_components.Count > 1)
                {
                    _components = _components.Randomize().ToList();
                }

                foreach (var components in _components)
                {
                    ApplySpecialAbility(components.Army, components.Range, components.Unit, components.Position);
                }
            }
        }

        /// <summary>
        /// Пытаемся получить компоненты для применения специальных возможностей
        /// </summary>
        private SpecialAbilityComponents? TryGetSpecialAbilityComponents(IArmy army, IArmy enemyArmy, int armyUnitsCount, ref int armyUnitIndex)
        {
            if (armyUnitIndex < armyUnitsCount)
            {
                var tmpArmyUnitIndex = armyUnitIndex;
                armyUnitIndex++;

				var specialUnit = TryGetSpecialAbilityUnit(army, tmpArmyUnitIndex);
                if (specialUnit != null)
                {
                    var range = Strategy.GetUnitsRangeForSpecialAbility(army, enemyArmy, specialUnit, tmpArmyUnitIndex);
					if (range != null)
					{
                        var targetArmy = specialUnit.IsFriendly ? army : enemyArmy;

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
        private ISpecialAbility TryGetSpecialAbilityUnit(IArmy army, int unitPosition)
        {
            var unit = army.Units[unitPosition];
            if (unit.IsAlive && unit is ISpecialAbility specialUnit)
            {
                return specialUnit;
            }

            return null;
        }

        /// <summary>
        /// Применить специальную возможность
        /// </summary>
        private void ApplySpecialAbility(IArmy targetArmy, IEnumerable<int> range, ISpecialAbility unit, int unitPosition)
        {
			unit.DoSpecialAction(targetArmy, range, unitPosition);
        }

		/// <summary>
		/// Удалить мертвые единицы армии
		/// </summary>
        private void CollectDeadUnits()
		{
            firstArmy.CollectDeadUnits();
			secondArmy.CollectDeadUnits();
		}

		#endregion
	}
}
