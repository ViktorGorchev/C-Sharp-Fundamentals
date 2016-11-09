using System;
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
    class Dreadnought : Starship
    {
        public Dreadnought(string name, StarSystem location) 
            : base(name, 200, 300, 150, 700, location)
        {
        }

       
        public override IProjectile ProduceAttack()
        {
            
            var damageCoefficient = (this.Shields / 2) + this.Damage;

            return new Laser(damageCoefficient);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            base.RespondToAttack(attack);
            this.Shields -= 50;
        }
    }
}
