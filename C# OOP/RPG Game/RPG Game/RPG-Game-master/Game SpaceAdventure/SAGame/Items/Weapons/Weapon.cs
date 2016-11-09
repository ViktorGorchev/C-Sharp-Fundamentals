using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame.Interfaces;

namespace SAGame.Items.Weapons
{
    public abstract class Weapon: Item, IDamageInflict 
    {
        
        public Weapon(Position position, int damage) : base(position)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }
    }
}
