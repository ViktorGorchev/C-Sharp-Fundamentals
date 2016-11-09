using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Enums;

namespace Blobs.Contracts
{
    public interface ICharacters
    {
        string Name { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        BehaviorTypeEnum Behavior { get; set; }
        AttackTypeEnum Attack { get; set; }
        bool IsAlive { get; set; }
    }
}
