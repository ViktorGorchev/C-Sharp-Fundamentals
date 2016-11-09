using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAGame_v0._2.Core;
using SAGame_v0._2.Core.Engine;
using SAGame_v0._2.Enums;
using SAGame_v0._2.GameDataBase;
using SAGame_v0._2.Interfaces;
using SAGame_v0._2.Items.Weapons;
using SAGame_v0._2.UI;

namespace SAGame_v0._2
{
    class GameMain
    {
        static void Main()
        {
            IInputReader reader = new InputReader();
            IRenderer renderer = new Renderer();
            IDataBase dataBase = new DataBase();
            IFactory factory = new Factory();
          

            IEngine engine = new GameEngine(reader, renderer, dataBase, factory);
            engine.Run();
        }

        
    }
}

