using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAGame.Models.Battleships
{
   
    public class RamShip : Character
    {
        //[Enemy
        private const int DefaultGunShipDamageStatus = 200;
        private const int DefaultGunshipDamage = 150;

        public RamShip(Position position) : base(DefaultGunshipDamage, DefaultGunShipDamageStatus, position)
        {
  
        }
       
    }
}
