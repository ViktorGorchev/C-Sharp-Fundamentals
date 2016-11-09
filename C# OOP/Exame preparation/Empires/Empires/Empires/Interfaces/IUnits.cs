using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Interfaces
{
    public interface IUnits
    {
        int Health { get; set; }
        int AttackDamage { get; set; }
    }
}
