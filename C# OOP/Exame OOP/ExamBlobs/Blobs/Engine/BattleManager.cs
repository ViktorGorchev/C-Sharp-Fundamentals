using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Contracts;

namespace Blobs.Engine
{
    public class BattleManager : IBattleManager
    {
        private int count = 0;
        
        public void BattelCommand(ICharacters attacker, ICharacters target)
        {
            if (attacker == null || target == null)
            {
                throw new AggregateException("Character must be first created!");
            }
            //TODO: implimehnt attack type and behavior;
            target.Health -= attacker.Damage;
           

        }
        
        public void UpdateGameTurn()
        {
            count++;
            //TODO:
        }
    }
}
