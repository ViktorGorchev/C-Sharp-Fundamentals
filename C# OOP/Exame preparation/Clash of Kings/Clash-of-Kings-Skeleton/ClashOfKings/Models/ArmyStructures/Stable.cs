using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClashOfKings.Models.Armies;

namespace ClashOfKings.Models.ArmyStructures
{
    class Stable : ArmyStructures
    {
        private const CityType StableRequiredCityType = CityType.FortifiedCity;
        private const decimal StableBuildCost = 75000m;
        private const int StableCapacity = 2500;
        private const UnitType StableUnitType = UnitType.Cavalry;

        public Stable() 
            : base(StableRequiredCityType, StableBuildCost, StableCapacity, StableUnitType)
        {
        }
    }
}
