using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAGame_v0._2.Interfaces;
using SAGame_v0._2.Items;
using SAGame_v0._2.Items.Weapons;

namespace SAGame_v0._2.Models.PlayerBattleShips
{
    public abstract class Player : Characters, IPlayer
    {
        private const int DefaultPlayerXPosition = 0;
        private const int DefaultPlayerYPosition = 0;

        private int munitions;
        private int energy;
        private readonly IList<Item> inventory = new List<Item>();
        private int intialNumberOfMunitions;

        protected Player(string name, int damage, int shieldStatus, int munitions, int energy)
            : base(name,
                  damage,
                  shieldStatus,
                  new Position(DefaultPlayerXPosition, DefaultPlayerYPosition))
        {
            this.Munitions = munitions;
            this.Energy = energy;
            this.intialNumberOfMunitions = this.Munitions;   
        }

        

        public int Munitions
        {
            get { return this.munitions; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Munitions should be a positive number");
                }
                this.munitions = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Energy should be a positive number in the range [0..100]");
                }
                this.energy = value;
            }
        }
        public IEnumerable<Item> Inventory => this.inventory;

 

        public void AddItemToInventory(Item item)
        {
            this.inventory.Add(item);
        }

        public abstract void AutoRepair();
       
    
        public override string ToString()
        {
            StringBuilder playerStatus = new StringBuilder();
            playerStatus.Append(base.ToString());
            playerStatus.AppendFormat(" , munitions: {0}, energy: {1}", this.Munitions, this.Energy);

            return playerStatus.ToString();
        }
    }
}