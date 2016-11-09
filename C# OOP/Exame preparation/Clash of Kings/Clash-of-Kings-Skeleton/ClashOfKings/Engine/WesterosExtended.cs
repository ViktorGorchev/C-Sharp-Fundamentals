using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClashOfKings.Contracts;

namespace ClashOfKings.Engine
{
    class WesterosExtended : Westeros, IIsGreatHouse
    {
        public bool IsGreatHouse { get; set; }

        public override void Update()
        {
            if (this.IsGreatHouse)
            {
                this.IsGreatHouse = false;
            }
            else if (this.IsGreatHouse == false)
            {
                this.IsGreatHouse = true;
            }


            foreach (var city in this.Cities)
            {
                city.Update();
            }

            foreach (var house in this.Houses)
            {
                house.Update();
            }
        }
    }


}
