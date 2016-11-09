using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SAGame.Items.Weapons
{
    
    public class RegularDC17: Weapon
    {
        //Item
        private const int DefaultRegularDC17Damage = 100;

        public RegularDC17(Position position) : base(position, DefaultRegularDC17Damage)
        {
        }
    }
}
