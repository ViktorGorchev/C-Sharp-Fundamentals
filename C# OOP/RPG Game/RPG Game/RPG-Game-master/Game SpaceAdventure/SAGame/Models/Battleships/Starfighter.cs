using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAGame.Models.Battleships
{
    public class Starfighter: Player
    {
        private const int DefaultPlayerXPosition = 0;
        private const int DefaultPlayerYPosition = 0;
        
        private const int DefaultStartfighterMunitions = 100;
        private const int DefaultStartfighterEnergy = 100;
        private const int DefaultStartfighterDamage = 75;
        private const int DefaultStartfighterDamageStatus = 140;
       

        public Starfighter() :
            base(DefaultStartfighterMunitions, DefaultStartfighterEnergy, DefaultStartfighterDamage,DefaultStartfighterDamageStatus, new Position(DefaultPlayerXPosition, DefaultPlayerYPosition))
        {
        }
    }
}
