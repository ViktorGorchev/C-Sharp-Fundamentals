using System;
using System.Collections.Generic;
using System.Linq;
using SAGame.Interfaces;

using SAGame.Items.Weapons;

namespace SAGame.Models.Battleships
{
    public abstract class Player : IPlayer

    {
        private int munitions;
        private int energy;
        private int damage;
        private int damageStatus;
        private Position position;
        
        private readonly IList<ICollectible> inventory;
        private int intialNumberOfMunitions;

        protected Player(int munitions, int energy, int damage, int damageStatus, Position position) 
       {
           this.Munitions = munitions;
           this.Energy = energy;
           this.Damage = damage;
           this.DamageStatus = damageStatus;
           this.Position = position;
           this.inventory = new List<ICollectible>();
           
       }
        

        public int Energy
        {
            get { return this.energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Energy should be a positive number in the range [0..100]");
                }
                this.energy = value;
            }
        }

        public int Damage
        {
            get
            {
                int damage = this.damage;

                damage = +this.inventory
                    .Where(w => w is Weapon)
                    .Cast<Weapon>()
                    .Select(w => w.Damage)
                    .Max();

                return damage;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage should be a positive number");
                }
                this.damage = value;

            }
        }

        public int DamageStatus
        {
            get { return this.damageStatus; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("DamageStatus should be a positive number");
                }
                this.damageStatus = value;
            }
        }

        public IEnumerable<ICollectible> Inventory
        {
            get { return this.inventory; }
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
                int intialNumberOfMunitions = this.munitions;
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

       

        public void Attack(ICharacter enemy)
        {
            intialNumberOfMunitions = this.Munitions;

            while (enemy.DamageStatus != 0)
            {
                enemy.DamageStatus =- this.Damage;

                if (this.Energy < 100)
                {
                    this.Energy++;
                }

                if (this.Energy == 100)
                {
                    enemy.DamageStatus = -2 * this.Damage; ;
                }

                this.Munitions =- 10;
                if (this.Munitions == 0)
                {
                    Console.WriteLine("No more munitions.Please Reload !!! ");
                    break;
                }
            }
        }

        public void AddItemToInventory(ICollectible item)
        {
            this.inventory.Add(item);
        }


        public void CollectMunitions()
        {
            while (this.Munitions < intialNumberOfMunitions)
            {
                this.Munitions =+ 10;
                
                if (this.Munitions == intialNumberOfMunitions)
                {
                    break;
                }
            }
        }
    }
}
