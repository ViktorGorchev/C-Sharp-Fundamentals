using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.EmpireBuildings;

namespace Empires.Core
{
    public class DataBase : IDataBase
    {
        private readonly IList<IBuildings> buildings; 

        public DataBase()
        {
            this.buildings = new List<IBuildings>();
           
        }

        public IEnumerable<IBuildings> Buildings => this.buildings;

        public void Add(IBuildings building)
        {
            this.buildings.Add(building);
        }

        public int Count()
        {
            return this.buildings.Count;
        }

        public IBuildings FirstInList()
        {
            if (this.buildings.Count == 0)
            {
                return null;
            }
            else
            {
                return this.buildings[0];
            }
        }
    }
    
}
