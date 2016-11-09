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
    public class Archery : Buildings
    {
        private const string Name = "Archery";
        private const int TurnsForArcherProduction = 3;
        private const int TurnsForGoldProduction = 2;
        private const int GoldQuantity = 5;

        public Archery(int unitTurnOfCreation, int turnOfCreation)
           : base(Name,TurnsForArcherProduction, TurnsForGoldProduction, GoldQuantity,
                 0, 0, unitTurnOfCreation, 0, turnOfCreation)
        {
        }

        public override IUnits ProduceUnit(int turnCount)
        {
            if (turnCount < TurnsForArcherProduction)
            {
                return null;
            }
            else
            {
                return new Archer();
            }
        }

        public override IResources ProduceResource(int turnCount)
        {
            if (turnCount < TurnsForGoldProduction)
            {
                return null;
            }
            else 
            {
                return new Gold(GoldQuantity);
            }
        }


       
    }
}
