using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Interfaces;
using SAGame_v0._2.Items;
using SAGame_v0._2.Models.EnemyBattleShips;
using SAGame_v0._2.Models.PlayerBattleShips;

namespace SAGame_v0._2.GameDataBase
{
    public class DataBase : IDataBase
    {
        private readonly IList<Player> player = new List<Player>();
        private readonly ICollection<IPlayer> playerShipsChoice = new List<IPlayer>()
        {
            new StarFighter(),
            new MillenniumFalcon()
        };
        private readonly IList<ICharacter> enemy = new List<ICharacter>();
        private readonly ICollection<Item> inventory = new List<Item>();
        private readonly ICollection<Item> items = new List<Item>();


        public IList<Player> Player => this.player;
        public IEnumerable<IPlayer> PlayerShipsChoice => this.playerShipsChoice;
        public IList<ICharacter> Enemy => this.enemy;
        public IEnumerable<Item> Inventory => this.inventory;
        public IEnumerable<Item> Items => this.items;


        public void AddToPlayerShipsChoice(IPlayer character)
        {
            this.playerShipsChoice.Add(character);
        }

        public void AddToPlayerInventory(Item item)
        {
            this.inventory.Add(item);
        }

        public void AddToItems(Item item)
        {
            this.items.Add(item);
        }
    }
}
