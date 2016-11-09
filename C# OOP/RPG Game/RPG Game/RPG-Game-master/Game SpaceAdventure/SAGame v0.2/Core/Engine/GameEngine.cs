using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Enums;
using SAGame_v0._2.GameDataBase;
using SAGame_v0._2.Interfaces;
using SAGame_v0._2.Items;
using SAGame_v0._2.Items.Weapons;
using SAGame_v0._2.Models.PlayerBattleShips;

namespace SAGame_v0._2.Core.Engine
{
    public class GameEngine : IEngine
    {
        private const int MinItemsCount = 5;
        private const int MaxItemsCount = 20;

        private const int MinEnemyCount = 5;
        private const int MaxEnemyCount = 20;
     

        private static readonly Random Rand = new Random();
        private readonly IInputReader reader;
        private readonly IRenderer renderer;
        private readonly IDataBase dataBase;
        private readonly IFactory factory;
       

        

        public GameEngine(IInputReader reader, IRenderer renderer, IDataBase dataBase, IFactory factory)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.dataBase = dataBase;
            this.factory = factory;
        }

        public bool IsRunning { get; private set; }


        public void Run()
        {

            var message = ChooseShipMessage();
            this.renderer.WriteLine(message);
            this.AddEnemies();
            this.AddItems();
            this.IsRunning = true;
            

            while (this.IsRunning)
            {
                
                var input = this.reader.ReadLine();
                var inputInfo = input.Split().ToArray();
                ExecuteCommand(inputInfo);
                this.DisplayMap();
                int enemiesLeft = this.dataBase.Enemy.Count();
                if (enemiesLeft == 0)
                {
                    this.ClearScreen();
                    this.renderer.WriteLine("Victory!!!");
                    break;
                }
                int itemsLeft = this.dataBase.Items.Count();
                if (itemsLeft == 0)
                {
                    this.ClearScreen();
                    this.renderer.WriteLine("Victory!!!");
                    break;
                }
                if (this.dataBase.Player.Any() && this.dataBase.Player[0].ShieldStatus < 0)
                {
                    this.ClearScreen();
                    this.renderer.WriteLine("You were defeated!!!");
                    break;
                }


            }
        }

        protected virtual void ExecuteCommand(string[] inputInfo)
        {
            var command = inputInfo[0].ToLower();
            var commandParams = inputInfo.Skip(1).ToArray();
            switch (command)
            {
                case "create":
                    var playerShip = this.factory.CreatePlayer(commandParams);
                    this.dataBase.Player.Add(playerShip);
                    break;
                case "w":           //up
                    this.dataBase.Player[0].Position = new Position(
                        this.dataBase.Player[0].Position.X, this.dataBase.Player[0].Position.Y - 1);
                    this.renderer.Clear();
                    this.CheckIfInMap();
                    this.CheckForCollision();
                    break;
                case "s":           //down
                    this.dataBase.Player[0].Position = new Position(
                        this.dataBase.Player[0].Position.X, this.dataBase.Player[0].Position.Y + 1);
                    this.renderer.Clear();
                    this.CheckIfInMap();
                    this.CheckForCollision();
                    break;
                case "a":           //left
                    this.dataBase.Player[0].Position = new Position(
                        this.dataBase.Player[0].Position.X - 1, this.dataBase.Player[0].Position.Y);
                    this.renderer.Clear();
                    this.CheckIfInMap();
                    this.CheckForCollision();
                    break;
                case "d":           //right
                    this.dataBase.Player[0].Position = new Position(
                        this.dataBase.Player[0].Position.X + 1, this.dataBase.Player[0].Position.Y);
                    this.renderer.Clear();
                    this.CheckIfInMap();
                    this.CheckForCollision();
                    break;
                case "status":
                    this.PrintStatus();
                    break;
                case "help":
                    PrintHelp();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    this.renderer.WriteLine("Unknown command!");
                    break;
            }
        }

        private string ChooseShipMessage()
        {
            StringBuilder message = new StringBuilder();
            message.Append("Choose your ship:");
            foreach (var ship in dataBase.PlayerShipsChoice)
            {
                message.AppendFormat(Environment.NewLine + ship);
            }
            return message.ToString();
        }

        private void AddEnemies()
        {

            int randEnemyCount = Rand.Next(MinEnemyCount, MaxEnemyCount);
            for (int i = 0; i < randEnemyCount; i++)
            {
                int enemyRandPosX = Rand.Next(1, Constants.MapWidth - 1);
                int enemyRandPosY = Rand.Next(1, Constants.MapHeight - 1);
                while (this.dataBase.Items.Any(e => e.Position.X == enemyRandPosX && e.Position.Y == enemyRandPosY))
                {
                     enemyRandPosX = Rand.Next(1, Constants.MapWidth - 1);
                     enemyRandPosY = Rand.Next(1, Constants.MapHeight - 1);
                }
                int randEnemyType = Rand.Next(1, 4);
                var enemy = this.factory.CreateEnemies(randEnemyType, enemyRandPosX, enemyRandPosY);
                this.dataBase.Enemy.Add(enemy);

            }
        }

        private void AddItems()
        {
            int randItemsCount = Rand.Next(MinItemsCount, MaxItemsCount);
            for (int i = 0; i < randItemsCount; i++)
            {

                int itemRandPosX = Rand.Next(1, Constants.MapWidth - 1);
                int itemRandPosY = Rand.Next(1, Constants.MapHeight - 1);

                while (this.dataBase.Enemy.Any(e => e.Position.X == itemRandPosY && e.Position.Y == itemRandPosY))
                {
                    itemRandPosX = Rand.Next(1, Constants.MapWidth - 1);
                    itemRandPosY = Rand.Next(1, Constants.MapHeight - 1);
                }
                int itemType = Rand.Next(1, 3);
                var item = this.factory.CreateItem(itemType, itemRandPosX, itemRandPosY);
                this.dataBase.AddToItems(item);

            }
        }


        private void CheckIfInMap()
        {
            if (this.dataBase.Player[0].Position.Y < 0)                                                 //up 
            {
                this.dataBase.Player[0].Position = new Position(
                        this.dataBase.Player[0].Position.X, this.dataBase.Player[0].Position.Y + 1);
            }
            if (this.dataBase.Player[0].Position.Y + 1 > Constants.MapHeight)                           //down
            {
                this.dataBase.Player[0].Position = new Position(
                       this.dataBase.Player[0].Position.X, this.dataBase.Player[0].Position.Y - 1);     
            }
            if (this.dataBase.Player[0].Position.X < 0)                                                 //left
            {
                this.dataBase.Player[0].Position = new Position(
                        this.dataBase.Player[0].Position.X + 1, this.dataBase.Player[0].Position.Y);   
            }
            if (this.dataBase.Player[0].Position.X + 1 > Constants.MapWidth)
            {
                this.dataBase.Player[0].Position = new Position(
                        this.dataBase.Player[0].Position.X - 1, this.dataBase.Player[0].Position.Y);    //right
            }
        }

        private void DisplayMap()
        {
            if (this.dataBase.Player.Count == 0)
            {
                return;
            }

            StringBuilder map = new StringBuilder();
            for (int row = 0; row < Constants.MapHeight; row++)
            {
                for (int col = 0; col < Constants.MapWidth; col++)
                {
                    if (this.dataBase.Player[0].Position.X == col && this.dataBase.Player[0].Position.Y == row)
                    {
                        map.Append(this.PlayerName(this.dataBase.Player[0].Name));
                    }
                    else if (this.dataBase.Enemy.Any())
                    {
                        foreach (var enemy in this.dataBase.Enemy)
                        {
                            if ((enemy.ShieldStatus > 0) && (enemy.Position.X == col && enemy.Position.Y == row))
                            {
                                map.Append(this.EnemyName(enemy.Name));
                            }
                        }
                    }
                    if (this.dataBase.Items.Any())
                    {
                        foreach (var item in this.dataBase.Items)
                        {
                            if (item.State == ItemState.Available && (item.Position.X == col && item.Position.Y == row))
                            {
                                map.Append(this.ItemName(item.Name));
                            }
                        }
                    }
                   if (this.CheckIfEmptySpace(col, row))
                    {
                        map.Append('.');
                    }
                }
                map.AppendLine();
            }
            this.renderer.WriteLine(map.ToString());
        }

        private char PlayerName(string name)
        {
            switch (name)
            {
                case "Starfighter":
                    return 'S';
                case "MillenniumFalcon":
                    return 'M';
                default:
                    throw new AggregateException("Unknown player name!");
            }
        }

        private char EnemyName(string name)
        {
            switch (name)
            {
                case "Gunship":
                    return 'G';
                case "Ramship":
                    return 'R';
                case "Warship":
                    return 'W';
                default:
                    throw new AggregateException("Unknown ship name!");
            }
        }

        private char ItemName(string name)
        {
            switch (name)
            {
                case "RegularDC17":
                    return 'D';
                case "Imperium":
                    return 'I';
               default:
                    throw new AggregateException("Unknown ship name!");
            }
        }

        private bool CheckIfEmptySpace(int col, int row)
        {
            if (this.dataBase.Player[0].Position.X == col && this.dataBase.Player[0].Position.Y == row)
            {
                return false;
            }
            
            foreach (var enemy in this.dataBase.Enemy)
            {
                if ((enemy.ShieldStatus > 0) && (enemy.Position.X == col && enemy.Position.Y == row))
                {
                    return false;
                }
            }

            foreach (var item in this.dataBase.Items)
            {
                if (item.State == ItemState.Available && (item.Position.X == col && item.Position.Y == row))
                {
                    return false;
                }
            }

            return true;
        }

        private void CheckForCollision()
        {
            var collidingObject = this.dataBase.Enemy.
                FirstOrDefault(e => e.Position.Equals(this.dataBase.Player[0].Position));

            var item = this.dataBase.Items.
                FirstOrDefault(e => e.Position.Equals(this.dataBase.Player[0].Position));

            //var item = collidingObject as Item;

            if (item != null)
            {
                this.dataBase.AddToPlayerInventory(item);
                this.renderer.WriteLine("Added item to inventory:" + item.GetType().Name);
                item.State = ItemState.Collected;
            }

            var enemy = collidingObject as ICharacter;

            if (enemy != null)
            {
                this.EnterAttackPhase(enemy);
            }
        }

        private void EnterAttackPhase(ICharacter enemy)
        {
            if (enemy.ShieldStatus == 0)
            {
                return;
            }

            this.renderer.WriteLine(
                "Enemy encountered: {0} (damage: {1}, shield status: {2})" ,
                enemy.GetType().Name,
                enemy.Damage,
                enemy.ShieldStatus);

            while (enemy.ShieldStatus > 0)
            {

                if (dataBase.Player[0].ShieldStatus < 0)
                {
                    break;
                }

                this.renderer.WriteLine("Do you want to attack? (y/n)");

                string choice = this.reader.ReadLine();

                while (choice != "n" & choice != "y")
                {
                    this.renderer.WriteLine("Invalid choice, please enter 'y' or 'n'.");
                    choice = this.reader.ReadLine();
                }

                switch (choice)
                {
                    case "n":
                        this.renderer.WriteLine("Loser !!!");
                        return;
                    case "y":
                        this.PerformAttack(enemy);
                        break;
                }
            }
        }
        private void PerformAttack(ICharacter enemy)
        {
            dataBase.Player[0].Damage = UpdateDamage();
           
            dataBase.Player[0].Attack(enemy);

           

            if (enemy.ShieldStatus <= 0)
            {
                this.dataBase.Enemy.Remove(enemy);
                this.renderer.WriteLine("Enemy was defeated!");
                this.dataBase.Player[0].AutoRepair();
                return;
            }
            
            enemy.Attack(this.dataBase.Player[0]);
            this.renderer.WriteLine("Damage taken!");
            this.renderer.WriteLine("Player shield points: {0}", this.dataBase.Player[0].ShieldStatus);
            this.renderer.WriteLine("Enemy shield points: {0}" , enemy.ShieldStatus);
        }

        private int UpdateDamage()
        {
            if (this.dataBase.Inventory.Any())
            {
                int updatedDamage = this.dataBase.Player[0].Damage;   

                updatedDamage += this.dataBase.Inventory
                    .Where(w => w is Weapon)
                    .Cast<Weapon>()
                    .Select(w => w.Damage)
                    .Max();
                return updatedDamage;
            }
            return this.dataBase.Player[0].Damage;
        }
        

        private void PrintStatus()
        {
            StringBuilder playerStatus = new StringBuilder();
            playerStatus.AppendFormat(this.dataBase.Player[0].ToString());
            if (this.dataBase.Inventory.Any())
            {
                playerStatus.Append(Environment.NewLine + "Items: ");
                foreach (var item in this.dataBase.Inventory)
                {
                    playerStatus.Append(item + ";");
                }
                playerStatus.Append(Environment.NewLine + "Player damage now: " + this.UpdateDamage());
            }
            this.renderer.WriteLine(playerStatus.ToString());
        }

        protected virtual void PrintHelp()
        {
            StringBuilder help = new StringBuilder();
            help.Append("create {Write the name of the ship you are going to play with (without {}) --> " +
                        "with this command you create your player" + Environment.NewLine +
                            "w --> go up" + Environment.NewLine +
                            "s --> go down" + Environment.NewLine +
                            "a --> go left" + Environment.NewLine +
                            "d --> go right" + Environment.NewLine +
                            "status --> pints the current player status" + Environment.NewLine +
                            "exit --> ends the game" + Environment.NewLine +
                            "Player: Starfighter --> S; MillenniumFalcon --> M" + Environment.NewLine +
                            "Enemies: Gunship --> G; Ramship --> R; Warship --> W;" + Environment.NewLine +
                            "Items: Imperium --> I; RegularDC17 --> D;");
            this.renderer.WriteLine(help.ToString());
        }

        private void ClearScreen()
        {
            this.renderer.Clear();
        }
    }
}
