namespace VegetableNinja.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using VegetableNinja.Contracts;

    public class DataBase : IDatabase
    {
        private readonly IList<IPlayer> players = new List<IPlayer>();
        private readonly IList<IItem> items = new List<IItem>();

        public DataBase()
        {
            this.Players = this.players;
            this.Items = this.items;
        }

        public IEnumerable<IPlayer> Players { get; set; }

        public IEnumerable<IItem> Items { get; set; }

        public void AddPlayer(IPlayer player)
        {
            this.players.Add(player);
        }

        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public void ChagePlayerPsition(string playerName, int row, int col)
        {
            for (int i = 0; i < this.Players.Count(); i++)
            {
                if (this.players[i].Name == playerName)
                {
                    this.players[i].Position = new Position(row, col);
                }
            }
        }

        public void PlayerTurn(string playerName, bool isOnTurn)
        {
            for (int i = 0; i < this.Players.Count(); i++)
            {
                if (this.players[i].Name == playerName)
                {
                    this.players[i].IsOnTurn = isOnTurn;
                }
            }
        }

        public void SetPower(string playerName, int newPower)
        {
            for (int i = 0; i < this.Players.Count(); i++)
            {
                if (this.players[i].Name == playerName)
                {
                    this.players[i].Power = newPower;
                }
            }
        }

        public void SetStamina(string playerName, int newStamina)
        {
            for (int i = 0; i < this.Players.Count(); i++)
            {
                if (this.players[i].Name == playerName)
                {
                    this.players[i].Power = newStamina;
                }
            }
        }

        public void SetCurrentItemSimbol(char itemSymbol, char newCharSymbol)
        {
            for (int i = 0; i < this.Items.Count(); i++)
            {
                if (this.items[i].ItemSymbol == itemSymbol)
                {
                    this.items[i].CurrentVegetableSymbol = newCharSymbol;
                }
            }
        }
    }
}
