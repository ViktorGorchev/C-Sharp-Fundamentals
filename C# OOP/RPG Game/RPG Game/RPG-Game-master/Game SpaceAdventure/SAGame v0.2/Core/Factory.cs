using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Interfaces;
using SAGame_v0._2.Items;
using SAGame_v0._2.Items.Weapons;
using SAGame_v0._2.Models.EnemyBattleShips;
using SAGame_v0._2.Models.PlayerBattleShips;

namespace SAGame_v0._2.Core
{
    public class Factory : IFactory
    {
        public virtual Player CreatePlayer(string[] commandParams)
        {
            if (commandParams == null)
            {
                throw new ArgumentNullException(nameof(commandParams),"Ship's name can't be null");
            }
            string shipName = commandParams[0].ToLower();

            switch (shipName)
            {
                case "starfighter":
                    return new StarFighter();
                case "millenniumfalcon":
                    return new MillenniumFalcon();
                default:
                    throw new AggregateException("The ship is not in the database!");
            }
        }

        public virtual ICharacter CreateEnemies(int enemyType, int x, int y)
        {
            if (x <= 0 && y <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(enemyType), 
                    "X and Y of the enemy ship can't be 0 or negative number!");
            }
            switch (enemyType)
            {
                case 1:
                    return new GunShip(new Position(x, y));
                case 2:
                    return new RamShip(new Position(x , y));
                case 3:
                    return new WarShip(new Position(x, y));
                default:
                    throw new AggregateException("Invalid enemy type!");
            }
        }

        public Item CreateItem(int itemType, int x, int y)
        {
            if (x <= 0 && y <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(itemType),
                    "X and Y of the item can't be 0 or negative number!");
            }
            switch (itemType)
            {
                case 1:
                    return new RegularDc17(new Position(x, y));
                case 2:
                    return new Imperium(new Position(x, y));
                default:
                    throw new AggregateException("Invalid enemy type!");
            }
        }
    }
}
