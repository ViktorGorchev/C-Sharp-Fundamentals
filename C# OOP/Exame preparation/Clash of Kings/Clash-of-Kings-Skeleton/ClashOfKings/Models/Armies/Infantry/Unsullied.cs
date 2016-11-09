using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfKings.Models.Armies.Infantry
{
    class Unsullied : MilitaryUnit
    {
     
        private const int UnsulliedArmor = 5;
        private const int UnsulliedDamage = 25;
        private const decimal UnsulliedTrainingCost = 42.5m;
        private const double UnsulliedUpkeepCost = 0.75;
        private const int UnsulliedHousingSpacesRequired = 1;
        private const UnitType UnsulliedArmyType = UnitType.Infantry;

        public Unsullied() 
            : base(UnsulliedArmor,
                  UnsulliedDamage,
                  UnsulliedTrainingCost,
                  UnsulliedUpkeepCost,
                  UnsulliedHousingSpacesRequired,
                  UnsulliedArmyType)
        {
        }
    }
}
