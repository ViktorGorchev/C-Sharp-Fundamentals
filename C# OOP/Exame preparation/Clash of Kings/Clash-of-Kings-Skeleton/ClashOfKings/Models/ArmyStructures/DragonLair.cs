using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClashOfKings.Models.Armies;

namespace ClashOfKings.Models.ArmyStructures
{
    class DragonLair : ArmyStructures
    {
        private const CityType DragonLairRequiredCityType = CityType.Capital;
        private const decimal DragonLairBuildCost = 200000m;
        private const int DragonLairCapacity = 3;
        private const UnitType DragonLairUnitType = UnitType.AirForce;
        

        public DragonLair() 
            : base(DragonLairRequiredCityType, DragonLairBuildCost, DragonLairCapacity, DragonLairUnitType)
        {
            
        }
        
    }
}
