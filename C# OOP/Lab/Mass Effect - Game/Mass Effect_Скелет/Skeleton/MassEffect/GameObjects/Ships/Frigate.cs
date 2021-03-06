﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;
using MassEffect.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    class Frigate : Starship
    {
        private int projectilesFired;

        public Frigate(string name, StarSystem location) 
            : base(name, 60, 50, 30, 220, location)
        {
            this.projectilesFired = 0;
        }

        
        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new PenetrationShell(this.Damage);
        }

       
        public override string ToString()
        {
            string output = base.ToString();
            if (this.Health > 0)
            {
                output += string.Format("{1}-Projectiles fired: {0}", this.projectilesFired, Environment.NewLine);
            }

            return output;                                                                                         
        }
    }
}
