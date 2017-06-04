using System.Collections.Generic;

namespace StackGame.Core.Configs
{
    /// <summary>
    /// Настройки
    /// </summary>
    public static class Configs
    {
        /// <summary>
        /// Настройки единиц армии
        /// </summary>
        public static Dictionary<UnitType, UnitParameters> Units = new Dictionary<UnitType, UnitParameters>
        {
            {
                UnitType.LightUnit, new UnitParameters
                {
                    Price = 25,
                    Health = 100,
                    Defence = 0,
                    Strength = 15,
                    Range = 1,
                    Chance = 50
                }
            },
			{
                UnitType.HeavyUnit, new UnitParameters
				{
					Price = 50,
					Health = 100,
					Defence = 50,
					Strength = 15
				}
			},
			{
                UnitType.ArcherUnit, new UnitParameters
				{
					Price = 75,
					Health = 100,
					Defence = 0,
					Strength = 10,
					Range = 3,
					Power = 15,
                    Chance = 50
				}
			},
			{
                UnitType.ClericUnit, new UnitParameters
				{
					Price = 75,
					Health = 100,
					Defence = 0,
					Strength = 5,
					Range = 3,
                    Power = 10,
                    Chance = 50
				}
			},
			{
                UnitType.MageUnit, new UnitParameters
				{
					Price = 100,
					Health = 100,
					Defence = 0,
					Strength = 5,
					Range = 3,
                    Chance = 50
				}
			},
			{
                UnitType.WallUnit, new UnitParameters
				{
					Price = 100,
					Health = 300,
					Defence = 0
				}
			}
        };
        /// <summary>
        /// Настройки улучшений армии
        /// </summary>
        public static Dictionary<UnitImproveType, UnitImproveParameters> UnitImproves = new Dictionary<UnitImproveType, UnitImproveParameters>
        {
            {
                UnitImproveType.Helmet, new UnitImproveParameters
                {
                    Defence = 20
                }
            },
			{
                UnitImproveType.Shield, new UnitImproveParameters
				{
					Defence = 30
				}
			},
			{
				UnitImproveType.Spear, new UnitImproveParameters
				{
                    Strength = 10
				}
			},
			{
                UnitImproveType.Horse, new UnitImproveParameters
				{
                    Health = 50,
                    Strength = 10
				}
			}
        };

        /// <summary>
        /// Стоимость армии
        /// </summary>
        public static readonly int ArmyCost = 100;
    }
}
