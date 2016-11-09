using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SAGame.Attributes;
using SAGame.Enums;
using SAGame.Interfaces;
using SAGame.Items.Teleports;
using SAGame.UI;
using SAGame.Items.Weapons;
using SAGame.Models.Battleships;

namespace SAGame.Engine
{
    public class Engine :IEngine
    {
        private readonly IList<IGameObject> entities;
        private readonly IRenderer renderer;
        private readonly InputReader inputReader;
        private readonly IPlayer player;

        public Engine(IRenderer renderer, InputReader inputReader, IPlayer player)
        {
            this.entities = MapCreator.PopulateMap();
            this.renderer = renderer;
            this.inputReader = inputReader;
            this.player = player;
        }



        public bool IsRunning { get; private set; }

        public void Run()
        {
            this.IsRunning = true;
            this.ShowHelp();

            while (this.IsRunning)
            {
                int enemiesLeft = this.entities.Count(e => e is ICharacter);

                if (enemiesLeft == 0)
                {
                    this.renderer.WriteLine("Victory!");
                    break;
                }

                string command = this.inputReader.ReadLine();

                try
                {
                    this.ProcessCommand(command);
                }
                catch (Exception ex)
                {
                    this.renderer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string command)
        {
            switch (command)
            {
                
                case "help":
                    this.ShowHelp();
                    break;
                case "left":
                    this.player.Position = new Position(this.player.Position.X - 1, this.player.Position.Y);
                    this.CheckForCollision();
                    break;
                case "right":
                    this.player.Position = new Position(this.player.Position.X + 1, this.player.Position.Y);
                    this.CheckForCollision();
                    break;
                case "up":
                    this.player.Position = new Position(this.player.Position.X, this.player.Position.Y - 1);
                    this.CheckForCollision();
                    break;
                case "down":
                    this.player.Position = new Position(this.player.Position.X, this.player.Position.Y + 1);
                    this.CheckForCollision();
                    break;
                case "status":
                    this.PrintStatus();
                    break;
                case "enemies":
                    this.ShowEnemyInfo();
                    break;
                case "clear":
                    this.ClearScreen();
                    break;
                case "map":
                    this.DisplayMap();
                    break;
                case "inventory":
                    this.ShowInventoryInfo();
                    break;
                case "surrender":
                    this.IsRunning = false;
                    this.renderer.WriteLine("Loser...");
                    break;
                default:
                    throw new ArgumentException("Unknown command.");
            }
        }

        private void ShowInventoryInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Player Inventory:");

            foreach (var collectible in this.player.Inventory)
            {
                
                if (collectible is Weapon)
                {
                    var item = collectible as Weapon;

                    sb.AppendFormat(
                        "{0} - Damage: {1}{2}",
                        item.GetType().Name,
                        item.Damage,
                        Environment.NewLine);
                }
                else if (collectible is Teleport)
                {
                    var item = collectible as Teleport;
                    sb.AppendFormat(
                        "{0}:{1}",
                        item.GetType().Name,
                        Environment.NewLine);
                }
            }

            this.renderer.WriteLine(sb.ToString().Trim());
        }

        private void CheckForCollision()
        {
            var collidingObject = this.entities
                .FirstOrDefault(e => e.Position.Equals(this.player.Position));

            var item = collidingObject as ICollectible;

            if (item != null)
            {
                this.player.AddItemToInventory(item);
                this.renderer.WriteLine("Added item to inventory: {0}", item.GetType().Name);
                item.State = ItemState.Collected;

                return;
            }

            var enemy = collidingObject as ICharacter;

            if (enemy != null)
            {
                this.EnterAttackPhase(enemy);
            }
        }

        private void EnterAttackPhase(ICharacter enemy)
        {
            if (enemy.DamageStatus == 0)
            {
                return;
            }

            this.renderer.WriteLine(
                "Enemy encountered: {0} (damage: {1}, damage status: {2})",
                enemy.GetType().Name,
                enemy.Damage,
                enemy.DamageStatus);

            while (enemy.DamageStatus > 0)
            {
                this.renderer.WriteLine("Do you want to attack? (y/n)");

                string choice = this.inputReader.ReadLine();

                while (choice != "n" & choice != "y")
                {
                    this.renderer.WriteLine("Invalid choice, please enter 'y' or 'n'.");
                    choice = this.inputReader.ReadLine();
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
            this.player.Attack(enemy);

            if (enemy.DamageStatus == 0)
            {
                this.entities.Remove(enemy);
                this.renderer.WriteLine("Enemy was defeated!");
                this.player.Damage += 2;
                return;
            }

            enemy.Attack(this.player);
            this.renderer.WriteLine("Damage taken!");
            this.renderer.WriteLine("Player damage status: {0}", this.player.DamageStatus);
            this.renderer.WriteLine("Enemy damage status: {0}", enemy.DamageStatus);
        }

        private void ShowEnemyInfo()
        {
            var enemies = Assembly.GetExecutingAssembly().GetTypes()
                 .Where(t => t.IsClass)
                 .Where(t => t.CustomAttributes
                     .Any(a => a.AttributeType == typeof(EnemyAttribute)))
                 .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var enemy in enemies)
            {
                var damage = enemy.GetFields().First(f => f.Name.EndsWith("Damage")).GetRawConstantValue();

                var damageStatus = enemy.GetFields().First(f => f.Name.EndsWith("Damage status")).GetRawConstantValue();

                var armor = enemy.GetFields().First(f => f.Name.EndsWith("Armor")).GetRawConstantValue();

                sb.Append(enemy.Name);
                sb.AppendFormat(": Damage: {0}, Hit Points: {1}, Armor: {2}", damage, damageStatus, armor);
                sb.AppendLine();
            }

            this.renderer.WriteLine(sb.ToString().Trim());
        }

        private void ClearScreen()
        {
            this.renderer.Clear();
        }

        private void DisplayMap()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("P - Player, T - Treasure (armor or weapon), other - Enemy");

            for (int row = 0; row < Constants.MapHeight; row++)
            {
                for (int col = 0; col < Constants.MapWidth; col++)
                {
                    if (this.player.Position.X == col && this.player.Position.Y == row)
                    {
                        sb.Append('P');
                        continue;
                    }

                    IGameObject currentObject = this.entities
                        .FirstOrDefault(e => e.Position.X == col && e.Position.Y == row);

                    if (currentObject is ICollectible && (currentObject as ICollectible).State == ItemState.Available)
                    {
                        sb.Append('T');
                    }
                    else if (currentObject is ICharacter && (currentObject as ICharacter).DamageStatus > 0)
                    {
                        sb.Append(currentObject.GetType().Name[0]);
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }

                sb.AppendLine();
            }

            this.renderer.WriteLine(sb.ToString());
        }

        private void PrintStatus()
        {
            int enemiesLeft = this.entities.Count(e => e is ICharacter && ((ICharacter)e).DamageStatus > 0);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(string.Format(
                "Player Stats: Damage status ({0}), Damage ({1}), Inventory: {2}",
                this.player.DamageStatus,
                this.player.Damage,
                string.Join(", ", this.player.Inventory.Select(item => item.GetType().Name))));
            sb.Append("Enemies left: " + enemiesLeft);

            this.renderer.WriteLine(sb.ToString());
        }

        private void ShowHelp()
        {
            StreamReader reader = new StreamReader(@"../../HelpInfo.txt");

            string info = reader.ReadToEnd();

            this.renderer.WriteLine(info);
        }
    }
}
}
