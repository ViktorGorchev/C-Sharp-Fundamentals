using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.Armies.Cavalry
{
    class Dothraki : MilitaryUnit
    {
        
        private const int DothrakiArmor = 5;
        private const int DothrakiDamage = 25;
        private const decimal DothrakiTrainingCost = 25m;
        private const double DothrakiUpkeepCost = 1.8;
        private const int DothrakiHousingSpacesRequired = 2;
        private const UnitType DothrakiArmyType = UnitType.Cavalry;

        public Dothraki() 
            : base(DothrakiArmor,
                  DothrakiDamage,
                  DothrakiTrainingCost,
                  DothrakiUpkeepCost,
                  DothrakiHousingSpacesRequired,
                  DothrakiArmyType)
        {
        }
    }
}
