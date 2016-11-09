using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Contracts;
using Blobs.Data;
using Blobs.Engine;
using Blobs.Enums;
using Blobs.Models;
using Blobs.UI;

namespace Blobs
{
    class BlobsMain
    {
        static void Main()
        {
            IReade reader = new Reader();
            IRender renderer = new Renderer();
            IFactory factory = new Factory();
            IDataBase dataBase = new DataBase();
            IBattleManager battleManager = new BattleManager();
            
            IEngine engine = new GameEngine(reader, renderer, factory, dataBase, battleManager);
            engine.Run();
        }
    }
}
