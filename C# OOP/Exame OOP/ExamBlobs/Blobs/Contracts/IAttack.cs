using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Enums;

namespace Blobs.Contracts
{
    public interface IAttack
    {
        int ImplimentAttackType(ICharacters character);
    }
}
