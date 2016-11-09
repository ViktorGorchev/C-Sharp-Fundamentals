using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;

namespace Empires.Models.EmpireUnits
{
    public abstract class Units : IUnits, IEmpire
    {
        private int health;
        private int attackDamage;

        protected Units(int health, int attackDamage)
        {
            this.Health = health;
            this.AttackDamage = attackDamage;
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Health can't be negative number or 0!");
                }
                this.health = value;
            }
        }

        public int AttackDamage
        {
            get { return this.attackDamage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "AttackDamage can't be negative number!");
                }
                this.attackDamage = value;
            }
        }
    }
}
