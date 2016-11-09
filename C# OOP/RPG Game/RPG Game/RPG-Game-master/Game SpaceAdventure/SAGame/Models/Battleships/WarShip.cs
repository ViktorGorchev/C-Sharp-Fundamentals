using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAGame.Models.Battleships
{
    
    public class WarShip: Character
    {
        //Enemy
        private const int DefaultGunShipDamageStatus = 270;
        private const int DefaultGunshipDamage = 100;

        public WarShip(Position position) : base(DefaultGunshipDamage, DefaultGunShipDamageStatus, position)
        {
        }
     
    }
}
