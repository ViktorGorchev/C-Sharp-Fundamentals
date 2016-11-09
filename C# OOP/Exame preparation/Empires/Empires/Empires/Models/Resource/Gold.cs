using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires.Models.Resource
{
    

    public class Gold : EmpireResources 
    {
        public static int ddd = 100;

        private const ResourceType GolgResource = ResourceType.Gold;
        
        public Gold(int quantity) 
            : base(GolgResource, quantity)
        {
        }
    }
}
