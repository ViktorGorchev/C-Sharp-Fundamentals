using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Interfaces
{
    public interface IBuildings
    {
        string BuildingName { get; }
        int TurnsForUnitProduction { get; }
        int TurnsForResourceProduction { get;}
        int ResourceQuantity { get;}
        int Units { get; set; }
        int Resources { get; set; }
        int UnitTurnOfCreation { get; set; }
        int ResourcesTurnOfCreation { get; set; }
        int TurnOfCreation { get; set; }
        

        IUnits ProduceUnit(int turnCount);
        IResources ProduceResource(int turnCount);
    }
}
