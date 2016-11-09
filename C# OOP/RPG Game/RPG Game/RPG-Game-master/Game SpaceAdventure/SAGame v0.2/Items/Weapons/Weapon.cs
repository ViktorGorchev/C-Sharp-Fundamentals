using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Interfaces;

namespace SAGame_v0._2.Items.Weapons
{
    public abstract class Weapon : Item, IDamageInflict
    {
        private int damage;

        protected Weapon(string name, Position position, int damage) 
            : base(name, position)
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Damage should be a positive number");
                }
                this.damage = value;
            }
        }

        public override string ToString()
        {
            StringBuilder weapon = new StringBuilder();
            weapon.Append(base.ToString() + " " + this.Damage);
            return weapon.ToString();
        }
    }
}
