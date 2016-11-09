using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Models.EmpireBuildings;

namespace Empires.Interfaces
{
    public interface IDataBase
    {
       IEnumerable<IBuildings> Buildings{ get;}
        void Add(IBuildings building);
        int Count();
        IBuildings FirstInList();
    }
}
