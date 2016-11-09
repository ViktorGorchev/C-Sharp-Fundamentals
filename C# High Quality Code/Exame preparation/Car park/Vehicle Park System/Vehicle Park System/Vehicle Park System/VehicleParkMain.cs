namespace Vehicle_Park_System
{
    using System.Globalization;
    using System.Threading;

    using Vehicle_Park_System.Contracts;
    using Vehicle_Park_System.Core;
    using Vehicle_Park_System.DataBase;
    using Vehicle_Park_System.IO;

    public class VehicleParkMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IUserInterface userInterface = new UserInterface();
            IDataBase dataBase = new VehicleDataBase();
            ICommandManager commandManager = new CommandManager(dataBase);

            IEngine engine = new Engine(userInterface, commandManager);
            engine.Run();
        }
    }
}