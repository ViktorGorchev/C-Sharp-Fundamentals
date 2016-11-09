
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAGame.Models.Battleships
{
   
    public class GunShip: Character
    {
        //Enemy
        private const int DefaultGunShipDamageStatus = 150;
        private const int DefaultGunshipDamage = 60;
        

        public GunShip(Position position) : base(DefaultGunshipDamage, DefaultGunShipDamageStatus, position)
        {
        }
      
    }
}
