using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Items;
using SAGame_v0._2.Models.PlayerBattleShips;

namespace SAGame_v0._2.Interfaces
{
    public interface IFactory
    {
        Player CreatePlayer(string[] commandParams);
        ICharacter CreateEnemies(int enemyType, int x, int y);
        Item CreateItem(int itemType, int x, int y);
    }
}
