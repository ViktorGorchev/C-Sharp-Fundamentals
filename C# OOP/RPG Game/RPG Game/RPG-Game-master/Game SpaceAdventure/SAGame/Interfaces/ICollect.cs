using System.Collections.Generic;

namespace SAGame.Interfaces
{
    public interface ICollect
    {
        IEnumerable<ICollectible> Inventory { get; }

        void AddItemToInventory(ICollectible item);
    }
}
