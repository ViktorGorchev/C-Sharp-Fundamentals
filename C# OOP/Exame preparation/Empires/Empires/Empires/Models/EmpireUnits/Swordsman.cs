using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.EmpireUnits
{
    class Swordsman : Units
    {
        private const int SwordsmanHealth = 40;
        private const int SwordsmanDamage = 13;

        public Swordsman() 
            : base(SwordsmanHealth, SwordsmanDamage)
        {
        }
    }
}
