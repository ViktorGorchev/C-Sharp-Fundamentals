using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.Resource
{
    public class Steel : EmpireResources
    {
        private const ResourceType SteelResource = ResourceType.Steel;

        public Steel(int quantity) 
            : base(SteelResource, quantity)
        {
        }
    }
}
