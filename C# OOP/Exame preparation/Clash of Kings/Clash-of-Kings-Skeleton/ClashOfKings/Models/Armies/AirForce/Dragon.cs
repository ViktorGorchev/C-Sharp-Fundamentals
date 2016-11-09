using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.Armies.AirForce
{
    class Dragon : MilitaryUnit
    {
        private const int DragonArmor = 700;
        private const int DragonDamage = 1200;
        private const decimal DragonTrainingCost = 500m;
        private const double DragonUpkeepCost = 100;
        private const int DragonHousingSpacesRequired = 1;
        private const UnitType DragonArmyType = UnitType.AirForce;
        

        public Dragon() 
            : base(DragonArmor,
                  DragonDamage,
                  DragonTrainingCost,
                  DragonUpkeepCost,
                  DragonHousingSpacesRequired,
                  DragonArmyType)
        {
        }
    }
}
