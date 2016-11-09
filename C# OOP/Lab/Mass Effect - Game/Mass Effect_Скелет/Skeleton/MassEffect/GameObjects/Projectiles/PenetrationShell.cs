using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassEffect.Interfaces;

namespace MassEffect.Projectiles
{
    class PenetrationShell : Projectile
    {
        public PenetrationShell(int damage) 
            : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            targetShip.Health -= this.Damage;
        }
    }
}
