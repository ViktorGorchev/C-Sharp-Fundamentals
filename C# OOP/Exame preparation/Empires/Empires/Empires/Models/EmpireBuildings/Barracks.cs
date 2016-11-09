using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.EmpireUnits;
using Empires.Models.Resource;

namespace Empires.Models.EmpireBuildings
{
    public class Barracks : Buildings
    {
        private const string Name = "Barracks";
        private const int TurnsForSwordsmanProduction = 4;
        private const int TurnsForSteelProduction = 3;
        private const int SteelQuantity = 10;
        
        public Barracks(int unitTurnOfCreation, int turnOfCreation)
           : base(Name,TurnsForSwordsmanProduction, TurnsForSteelProduction, SteelQuantity, 
                 0, 0, unitTurnOfCreation, 0, turnOfCreation)
        {
        }

        
        public override IUnits ProduceUnit(int turnCount)
        {
            if (turnCount < TurnsForSwordsmanProduction)
            {
                return null;
            }
            else
            {
                return new Swordsman();
            }
        }

        public override IResources ProduceResource(int turnCount)
        {
            if (turnCount < TurnsForSteelProduction)
            {
                return null;
            }
            else
            {
                return new Steel(SteelQuantity);
            }
        }

       
    }
}
