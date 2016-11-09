using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.Models.Items
{
    class Pill : Bonus
    {
        private const int DefaultHealthEffect = 0;
        private const int DefaultDefenseEffect = 0;
        private const int DefaultAttackEffect = 100;

        public Pill(string id) 
            : base(id, DefaultHealthEffect, DefaultDefenseEffect, DefaultAttackEffect)
        {
            this.Countdown = 1;
            this.Timeout = 1;
            this.HasTimedOut = false;
        }
    }
}
