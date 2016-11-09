using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Models.Resource;

namespace Empires.Interfaces
{
    public interface IResources
    {
        ResourceType TypeOfResource { get; }
        int Quantity { get; set; }
    }
}
