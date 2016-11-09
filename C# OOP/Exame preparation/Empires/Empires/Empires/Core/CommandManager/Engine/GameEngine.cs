using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Empires.Interfaces;
using Empires.Models.EmpireBuildings;
using Empires.Models.EmpireUnits;
using Empires.Models.Resource;

namespace Empires.Core.CommandManager.Engine
{
    public class GameEngine : IEngine, IEmpire
    {
        
        public GameEngine(IReader inputReader, IRender outputRender, IDataBase dataBase)
        {
            this.InputReader = inputReader;
            this.OutputRender = outputRender;
            this.DataBase = dataBase;
        }

        public IReader InputReader { get; }
        public IRender OutputRender { get; }
        public IDataBase DataBase { get; }
        protected int TurnCount { get; set; }
        
        public void Run()
        {
            this.TurnCount = 0;   //-1

            while (true)
            {
                var input = this.InputReader.Reade();
                
                var commandInfo = input.Split().ToArray();

                ExecuteCommand(commandInfo);
                Update();
                this.TurnCount++;
                
            }
           
        }

        protected virtual void ExecuteCommand(string[] commandInfo)
        {
            var command = commandInfo[0].ToLower();
            
            switch (command)
            {
                case "build":
                    Build(commandInfo[1].ToLower());
                    break;
                case "skip":
                    break;
                case "empire-status":
                    PrintStatus();
                    break;
                case "armistice":
                    Environment.Exit(0);
                    break;
                default:
                    this.OutputRender.Render("Ïnvalid command!");
                    break;
            }
        }

        protected virtual void Build(string typeOfBuilding)
        {
            switch (typeOfBuilding)
            {
                case "barracks":
                    this.DataBase.Add(new Barracks(this.TurnCount, this.TurnCount));
                    break;
                case "archery":
                    this.DataBase.Add(new Archery(this.TurnCount, this.TurnCount));
                    break;
                default:
                    this.OutputRender.Render("Invalid building type!");
                    break;
            }
        }

        private void Update()
        {
            foreach (var building in DataBase.Buildings)
            {
                if (this.TurnCount - building.UnitTurnOfCreation >= building.TurnsForUnitProduction)
                {
                    building.Units++;
                    building.UnitTurnOfCreation = this.TurnCount;
                }

                if (building.ResourcesTurnOfCreation >= building.TurnsForResourceProduction)
                {
                    building.Resources += building.ResourceQuantity;
                    building.ResourcesTurnOfCreation = 1;
                }
                else
                {
                    building.ResourcesTurnOfCreation++;
                }
            }
        }

        public void PrintStatus()
        {
            StringBuilder status = new StringBuilder();
            status.AppendFormat("Treasury:" + Environment.NewLine +
           "--Gold: " + TotalGold() + Environment.NewLine +
            "--Steel: " + TotalSteel() + Environment.NewLine +
            "Buildings:" + Environment.NewLine);
            foreach (var building in DataBase.Buildings)
            {
                string unitName;
                string resourceName;
                if (building is Barracks)
                {
                    unitName = "Swordsman";
                    resourceName = "Steel";
                }
                else 
                {
                    unitName = "Archer";
                    resourceName = "Gold";
                }

                if (DataBase.Count() == 0)
                {
                    status.AppendLine("N/A");
                }
                else 
                {
                    status.AppendFormat("--{0}: {1} turns ({2} turns until {3}, {4} turns until {5}){6}",
                        building.BuildingName,
                        (this.TurnCount - building.TurnOfCreation) - 1,
                        building.TurnsForUnitProduction - (this.TurnCount - building.UnitTurnOfCreation) + 1,
                        unitName,
                        building.TurnsForResourceProduction - (building.ResourcesTurnOfCreation) + 1,
                        resourceName,
                        Environment.NewLine);
                }
            }
            status.Append("Units:");

            if (TotalSwordsmen() == 0 && TotalArchers() == 0)
            {
                status.AppendFormat(Environment.NewLine + "N/A");
            }
            else if (DataBase.Count() > 0 && this.DataBase.FirstInList() is Barracks)
            {
                if (TotalSwordsmen() > 0)
                {
                    status.AppendFormat(Environment.NewLine + "--Swordsman: " + TotalSwordsmen());
                }
                if (TotalArchers() > 0)
                {
                   status.AppendFormat(Environment.NewLine + "--Archer: " + TotalArchers());
                }
            }
            else if (DataBase.Count() > 0 && this.DataBase.FirstInList() is Archery)
            {
                if (TotalArchers() > 0)
                {
                    status.AppendFormat(Environment.NewLine + "--Archer: " + TotalArchers());
                }
                if (TotalSwordsmen() > 0)
                {
                    status.AppendFormat(Environment.NewLine + "--Swordsman: " + TotalSwordsmen());
                }
            }
            this.OutputRender.Render(status.ToString());
        }

        public int TotalArchers()
        {
            int archers = 0;
            foreach (var building in DataBase.Buildings)
            {
                if (building is Archery)
                {
                    archers += building.Units;
                }
            }
            return archers;
        }

        public int TotalSwordsmen()
        {
            int swordsmen = 0;
            foreach (var building in DataBase.Buildings)
            {
                if (building is Barracks)
                {
                    swordsmen += building.Units;
                }
            }
            return swordsmen;
        }

        public int TotalGold()
        {
            int gold = 0;
            foreach (var building in DataBase.Buildings)
            {
                if (building is Archery)
                {
                    gold += building.Resources;
                }
            }
            return gold;
        }

        public int TotalSteel()
        {
            int steel = 0;
            foreach (var building in DataBase.Buildings)
            {
                if (building is Barracks)
                {
                    steel += building.Resources;
                }
            }
            return steel;
        }

       
    }
}
