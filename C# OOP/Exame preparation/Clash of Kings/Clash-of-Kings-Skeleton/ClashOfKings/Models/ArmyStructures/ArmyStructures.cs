using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClashOfKings.Contracts;
using ClashOfKings.Models.Armies;

namespace ClashOfKings.Models.ArmyStructures
{
    abstract class ArmyStructures : IArmyStructure
    {
        private decimal buildCost;
        private int capacity;
        
        protected ArmyStructures(CityType requiredCityType, decimal buildCost, int capacity, UnitType unitType)
        {
            this.BuildCost = buildCost;
            this.Capacity = capacity;
        }

        public CityType RequiredCityType { get; private set; }
        public decimal BuildCost
        {
            get { return this.buildCost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "buildCost",
                        "An army structure's cost cannot be negative");
                }

                this.buildCost = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "capacity",
                        "Capacity cannot be negative");
                }

                this.capacity = value;
            }
        }

        public UnitType UnitType { get; private set; }
        

    }
}
