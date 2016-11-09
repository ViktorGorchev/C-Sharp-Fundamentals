using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame.Interfaces;
using SAGame.UI;

namespace SAGame.Core.Engine
{
    public class GameEngine : IEngine
    {
        private readonly IInputReader reader;
        private readonly IRenderer renderer;

        public GameEngine(IInputReader reader, IRenderer renderer)
        {
            this.reader = reader;
            this.renderer = renderer;
        }

        public virtual void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();
                var inputInfo = input.Split().ToArray();
                ExecuteCommand(inputInfo);
            }
        }

        protected virtual void ExecuteCommand(string[] inputInfo)
        {
            var command = inputInfo[0].ToLower();
            var commandParams = inputInfo.Skip(1).ToArray();
            switch (command)
            {
                case "create":
                    //TODO
                    break;
                case "w":           //up
                    //TODO up
                    break;
                case "s":           //down
                    //TODO: down
                    break;
                case "a":           //left
                     //TODO: left
                        break;
                case "d":           //right
                    //TODO right
                    break;
                case "status":
                    //TODO
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

        protected virtual void PrintHelp()
        {
            StringBuilder help = new StringBuilder();
            help.Append("create {Write the name of the ship you are going to play with (without {})} --> " +
                            "with this command you create your player" + Environment.NewLine + 
                            "w --> go up" + Environment.NewLine +
                            "s --> go down" + Environment.NewLine +
                            "a --> go left" + Environment.NewLine +
                            "d --> go right" + Environment.NewLine +
                            "status --> pints the current player status" + Environment.NewLine +
                            "exit --> ends the game");
            this.renderer.WriteLine(help.ToString());
        }
    }
}
