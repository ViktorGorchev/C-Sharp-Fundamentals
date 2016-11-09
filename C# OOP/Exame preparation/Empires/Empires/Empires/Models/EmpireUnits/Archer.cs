using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.EmpireUnits
{
    class Archer : Units
    {
       private const int ArcherHealth = 25;
        private const int ArcherDamage = 7;

        public Archer() 
            : base(ArcherHealth, ArcherDamage)
        {
        }
    }
}
