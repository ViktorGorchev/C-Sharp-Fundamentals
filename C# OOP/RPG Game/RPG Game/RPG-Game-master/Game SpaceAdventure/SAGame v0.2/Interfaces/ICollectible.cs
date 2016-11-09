using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Enums;

namespace SAGame_v0._2.Interfaces
{
    public interface ICollectible
    {
        ItemState State { get; set; }
    }
}
