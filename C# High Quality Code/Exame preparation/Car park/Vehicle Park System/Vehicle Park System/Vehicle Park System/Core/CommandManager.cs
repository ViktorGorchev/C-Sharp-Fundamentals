namespace Vehicle_Park_System.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using System.Web.Script.Serialization;

    using Vehicle_Park_System.Contracts;
    using Vehicle_Park_System.Models;
    using Vehicle_Park_System.Models.Parking;

    internal class CommandManager : ICommandManager
    {
        private readonly IDataBase dataBase;
        
        internal CommandManager(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public string ExecuteCommand(string commandLine)
        {
            string commandName = commandLine.Substring(0, commandLine.IndexOf(' '));
            Dictionary<string, string> parameturs =
                new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(
                    commandLine.Substring(commandLine.IndexOf(' ') + 1));
           
            if (commandName != "SetupPark" && this.dataBase.VehiclePark.Count == 0)
            {
                return "The vehicle park has not been set up";
            }

            string commandResult;
            switch (commandName)
            {
                case "SetupPark":
                    int sector = int.Parse(parameturs["sectors"]);
                    int placesPerSector = int.Parse(parameturs["placesPerSector"]);

                    this.dataBase.VehiclePark.Add(new VehiclePark(sector, placesPerSector, this.dataBase));

                    for (int i = 1; i <= sector; i++)
                    {
                        this.dataBase.FreePlaces[i] = placesPerSector;
                    }

                    commandResult = "Vehicle park created";

                    return commandResult;
                case "Park":
                    commandResult = this.ParkVehicle(parameturs);

                    return commandResult;
                case "Exit":
                    string licensePlate = parameturs["licensePlate"];
                    DateTime endTime = DateTime.Parse(parameturs["time"], null, DateTimeStyles.RoundtripKind);
                    decimal money = decimal.Parse(parameturs["paid"]);

                    commandResult = this.dataBase.VehiclePark[0].ExitVehicle(licensePlate, endTime, money);

                    return commandResult;
                case "Status":
                    commandResult = this.dataBase.VehiclePark[0].GetStatus();

                    return commandResult;
                case "FindVehicle":
                    commandResult = this.dataBase.VehiclePark[0].FindVehicle(parameturs["licensePlate"]);

                    return commandResult;
                case "VehiclesByOwner":
                    commandResult = this.dataBase.VehiclePark[0].FindVehiclesByOwner(parameturs["owner"]);

                    return commandResult;
                default:
                    throw new AggregateException("Invalid command.");
            }
        }

        private string ParkVehicle(Dictionary<string, string> parameturs)
        {
            string commandResult;
            switch (parameturs["type"])
            {
                case "car":
                    commandResult = this.dataBase.VehiclePark[0].InsertCar(
                        new Car(
                                parameturs["licensePlate"],
                                parameturs["owner"],
                                int.Parse(parameturs["hours"])),
                            int.Parse(parameturs["sector"]),
                            int.Parse(parameturs["place"]),
                            DateTime.Parse(parameturs["time"], null, DateTimeStyles.RoundtripKind));

                    return commandResult;
                case "motorbike":

                    commandResult = this.dataBase.VehiclePark[0].InsertMotorbike(
                        new Motorbike(
                            parameturs["licensePlate"],
                            parameturs["owner"],
                            int.Parse(parameturs["hours"])),
                        int.Parse(parameturs["sector"]),
                        int.Parse(parameturs["place"]),
                        DateTime.Parse(parameturs["time"], null, DateTimeStyles.RoundtripKind));

                    return commandResult;
                case "truck":
                    commandResult = this.dataBase.VehiclePark[0].InsertTruck(
                            new Truck(
                                parameturs["licensePlate"],
                                parameturs["owner"],
                                int.Parse(parameturs["hours"])),
                            int.Parse(parameturs["sector"]),
                            int.Parse(parameturs["place"]),
                            DateTime.Parse(parameturs["time"], null, DateTimeStyles.RoundtripKind));

                    return commandResult;
                default:
                    throw new AggregateException("Invalid Рark command.");
            }
        }
    }
}