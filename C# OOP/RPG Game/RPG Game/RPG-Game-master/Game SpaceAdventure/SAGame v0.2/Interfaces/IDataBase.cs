using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Items;
using SAGame_v0._2.Models.PlayerBattleShips;

namespace SAGame_v0._2.Interfaces
{
    public interface IDataBase : ICollect
    {
        IList<Player> Player { get; }
        IEnumerable<IPlayer> PlayerShipsChoice { get; }
        IList<ICharacter> Enemy { get; }
        IEnumerable<Item> Items { get; }

        void AddToPlayerShipsChoice(IPlayer character);
        void AddToItems(Item item);
    }
}
