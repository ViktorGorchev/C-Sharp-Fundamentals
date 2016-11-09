using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAGame_v0._2.Models.PlayerBattleShips
{
    class MillenniumFalcon : Player
    {
        private const string DefaultMillenniumFalconName = "MillenniumFalcon";
        private const int DefaultMillenniumFalconDamage = 100;
        private const int DefaultMillenniumFalconShieldStatus = 160;
        private const int DefaultMillenniumFalconMunitions = 80;
        private const int DefaultMillenniumFalconEnergy = 100;

        public MillenniumFalcon() 
            : base(DefaultMillenniumFalconName, 
                  DefaultMillenniumFalconDamage, 
                  DefaultMillenniumFalconShieldStatus, 
                  DefaultMillenniumFalconMunitions, 
                  DefaultMillenniumFalconEnergy)
        {
        }
        public override void AutoRepair()
        {
            this.ShieldStatus = DefaultMillenniumFalconShieldStatus;

        }

    }
}
