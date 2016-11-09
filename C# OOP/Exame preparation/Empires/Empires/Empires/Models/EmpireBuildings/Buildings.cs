using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.EmpireUnits;

namespace Empires.Models.EmpireBuildings
{
    public abstract class Buildings : IBuildings, IEmpire
    {
        private int turnsForUnitProduction;
        private int turnsForResourceProduction;
        private int resourceQuantity;
        private int units;
        private int resources;
        //private int unitTurnOfCreation;
        //private int resourcesTurnOfCreation;
        //private int turnOfCreation;

        protected Buildings(string buildingName, int turnsForUnitProduction, int turnsForResourceProduction, int resourceQuantity, 
            int units, int resources, int unitTurnOfCreation, int resourcesTurnOfCreation, int turnOfCreation)
        {
            this.BuildingName = buildingName;
            this.TurnsForUnitProduction = turnsForUnitProduction;
            this.TurnsForResourceProduction = turnsForResourceProduction;
            this.ResourceQuantity = resourceQuantity;
            this.Units = units;
            this.Resources = resources;
            this.UnitTurnOfCreation = unitTurnOfCreation;
            this.ResourcesTurnOfCreation = resourcesTurnOfCreation;
            this.TurnOfCreation = turnOfCreation;
        }

        public string BuildingName { get; }
        public int TurnsForUnitProduction
        {
            get { return this.turnsForUnitProduction; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),"Turns for unit producion must be more than 0!");
                }
                this.turnsForUnitProduction = value;
            }
        }

        public int TurnsForResourceProduction
        {
            get { return this.turnsForResourceProduction; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Turns for resource production must be more than 0!");
                }
                this.turnsForResourceProduction = value;
            }
        }

        public int ResourceQuantity
        {
            get { return this.resourceQuantity; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Resource quantity must be more than 0!");
                }
                this.resourceQuantity = value;
            }
        }

        public int Units
        {
            get { return this.units; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Unit can't be a negative number!");
                }
                this.units = value;
            }
        }

        public int Resources
        {
            get { return this.resources; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Resource can't be a negative number!");
                }
                this.resources = value;
            }
        }

        public int UnitTurnOfCreation { get; set; }
        public int ResourcesTurnOfCreation { get; set; }
        public int TurnOfCreation { get; set; }

        public abstract IUnits ProduceUnit(int turnCount);
        
        public abstract IResources ProduceResource(int turnCount);

       
    }
}
