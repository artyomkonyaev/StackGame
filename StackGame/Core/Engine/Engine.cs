using System.Collections.Generic;
using System.Linq;
using StackGame.Loggers;
using StackGame.Observers;
using StackGame.Core.Commands;
using StackGame.Core.Strategies;
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
        public IStrategy Strategy;

        /// <summary>
        /// Менеджер команд
        /// </summary>
        public CommandManager CommandManager;

        /// <summary>
        /// Закончена ли игра
        /// </summary>
        public bool IsGameEnded => FirstArmy.IsAllDead || SecondArmy.IsAllDead;

		/// <summary>
		/// Количество шагов без смертей
		/// </summary>
		public int CountTurnsWithoutDeath { get; set; }

        /// <summary>
        /// Может ли сделать следующий ход
        /// </summary>
        public bool IsCanMakeNextStep => CountTurnsWithoutDeath < Configs.Configs.MaxTurnsWithoutDeathCount;

        /// <summary>
        /// Экземпляр класса
        /// </summary>
        private static Engine instance;

        /// <summary>
        /// Первая армия
        /// </summary>
        public IArmy FirstArmy { get; private set; }
        /// <summary>
        /// Вторая армия
        /// </summary>
        public IArmy SecondArmy { get; private set; }

        #endregion

        #region Инициализация

        private Engine()
        { }

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
        /// Начать новую игру
        /// </summary>
        public void NewGame(int armyCost)
        {
			// Создание армий
			var factory = new RandomUnitsFactory();
			
            FirstArmy = new Army.Army("Белая", factory, armyCost);
			SecondArmy = new Army.Army("Черная", factory, armyCost);

			// Добавление наблюдателей для единиц армий
			var observers = new List<IObserver>
			{
				new FileObserver("DeadLog.txt"),
				new BeepObserver()
			};

			AddObservers(FirstArmy, observers);
			AddObservers(SecondArmy, observers);

			// Создание менеджера команд
			ILogger logger = new ConsoleLogger();
			CommandManager = new CommandManager(logger);

			// Замена тяжелых пехотинцев на прокси
			logger = new FileLogger("HeavyUnitProxyLog.txt");

			ReplaceHeavyUnitsWithProxy(FirstArmy, logger);
			ReplaceHeavyUnitsWithProxy(SecondArmy, logger);

			// Выбор стратегии
			Strategy = new Strategy1Vs1();

            // Обнуление количества шагов без смертей
            CountTurnsWithoutDeath = 0;
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
        public void NextStep() 
        {
            if (!IsCanMakeNextStep)
            {
                return;
            }

            MeleeAttack();
            SpecialAbilityAttack();
            CollectDeadUnits();

            CommandManager.EndTurn();
        }

        /// <summary>
        /// Играть до конца
        /// </summary>
        public void PlayToEnd()
        {
            while (IsCanMakeNextStep)
            {
                NextStep();

                if (IsGameEnded)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Рукопашная атака
        /// </summary>
        private void MeleeAttack()
        {
            var queue = Strategy.GetOpponentsQueue(FirstArmy, SecondArmy);
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
                    if (Helpers.Random.Next(4) == 0)
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
            var firstArmyUnitsCount = FirstArmy.Units.Count;
            var firstArmyUnitIndex = 0;

            var secondArmyUnitsCount = SecondArmy.Units.Count;
            var secondArmyUnitIndex = 0;

            while (firstArmyUnitIndex < firstArmyUnitsCount || secondArmyUnitIndex < secondArmyUnitsCount)
            {
                var _components = new List<SpecialAbilityComponents>();

                var firstArmyComponents = TryGetSpecialAbilityComponents(FirstArmy, SecondArmy, firstArmyUnitsCount, ref firstArmyUnitIndex);
                if (firstArmyComponents.HasValue)
                {
                    var specialAbilityComponents = firstArmyComponents.Value;
                    _components.Add(specialAbilityComponents);
                }

				var secondArmyComponents = TryGetSpecialAbilityComponents(SecondArmy, FirstArmy, secondArmyUnitsCount, ref secondArmyUnitIndex);
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
            var firstArmyDeadUnitsCount = FirstArmy.CollectDeadUnits();
			var secondArmyDeadUnitsCount = SecondArmy.CollectDeadUnits();

            int newCountTurnsWithoutDeath;
            if (firstArmyDeadUnitsCount == 0 && secondArmyDeadUnitsCount == 0)
            {
                newCountTurnsWithoutDeath = CountTurnsWithoutDeath + 1;
            }
            else
            {
                newCountTurnsWithoutDeath = 0;
            }

			var command = new ChangeCountTurnsWithoutDeathCommand(CountTurnsWithoutDeath, newCountTurnsWithoutDeath);
			CommandManager.Execute(command);
		}

        /// <summary>
        /// Изменить стратегию
        /// </summary>
        public void ChangeStrategy(IStrategy strategy)
        {
            if (Strategy.GetType() != strategy.GetType())
            {
                ICommand command = new ChangeStrategyCommand(Strategy, strategy, CountTurnsWithoutDeath);
                CommandManager.Execute(command);

                CommandManager.EndTurn();
            }
        }

		#endregion
	}
}
