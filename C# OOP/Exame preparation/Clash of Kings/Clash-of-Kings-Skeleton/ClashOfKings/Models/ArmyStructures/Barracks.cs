using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClashOfKings.Models.Armies;

namespace ClashOfKings.Models.ArmyStructures
{
    class Barracks: ArmyStructures
    {
        private const CityType BarracksRequiredCityType = CityType.Keep;
        private const decimal BarracksBuildCost = 15000m;
        private const int BarracksCapacity = 5000;
        private const UnitType BarracksUnitType = UnitType.Infantry;
        

        public Barracks() 
            : base(BarracksRequiredCityType, BarracksBuildCost, BarracksCapacity, BarracksUnitType)
        {
            
        }
        
        
    }
}
