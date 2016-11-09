using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAGame_v0._2.Items.Weapons
{
    public class RegularDc17 : Weapon
    {
        private const string DefaultRegularDc17Name = "RegularDC17";
        private const int DefaultRegularDc17Damage = 100;
        
        public RegularDc17(Position position) 
            : base(DefaultRegularDc17Name, position, DefaultRegularDc17Damage)
        {
        }
    }
}
