using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Items;

namespace SAGame_v0._2.Interfaces
{
    public interface ICollect
    {
        IEnumerable<Item> Inventory { get; }
        void AddToPlayerInventory(Item item);
    }
}
