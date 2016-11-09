using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Contracts
{
    public interface IBattleManager
    {
        void BattelCommand(ICharacters attacker, ICharacters target);
        void UpdateGameTurn();
    }
}
