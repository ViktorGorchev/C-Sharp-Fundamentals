using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Core;
using Empires.Core.CommandManager;
using Empires.Core.CommandManager.Engine;
using Empires.Interfaces;
using Empires.Models.EmpireBuildings;
using Empires.Models.EmpireUnits;
using Empires.Models.Resource;
using Empires.UI;

namespace Empires
{
    public class EmpiresMain
    {
        static void Main()
        {
            IReader inputReader = new Reader();
            IRender outputRender = new Renderer();
            IDataBase dataBase = new DataBase();
            

            IEngine engine = new GameEngine(inputReader, outputRender, dataBase);
            engine.Run();

            //Barracks b = new Barracks(0);
            //b.Resources = 5;

            //Console.WriteLine(b.GetType());

        }
    }
}
