namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Theatre.Contracts;
    using Theatre.Core;
    using Theatre.Models;
    using Theatre.UI;

    public class TheatreMain
    {
       public static void Main()
        {
           System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

           IReader reader = new Reader();
           IRenderer renderer = new Renderer();
           IDataBase dataBase = new DataBase();
           IPerformanceDatabase database = new PerformanceDatabase(dataBase);
           IEngine engine = new Engine(reader, renderer, database);
           engine.Run();
       }
    }
}