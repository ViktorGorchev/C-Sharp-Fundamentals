namespace Vehicle_Park_System.DataBase
{
    using System;
    using System.Collections.Generic;

    using Vehicle_Park_System.Contracts;

    public class VehicleDataBase : IDataBase
    {
        public VehicleDataBase()
        {
            this.VehiclePark = new List<IVehiclePark>();
            this.VehicleInPark = new Dictionary<IVehicle, string>();
            this.Park = new Dictionary<string, IVehicle>();
            this.NumberPlates = new Dictionary<string, IVehicle>();
            this.Time = new Dictionary<IVehicle, DateTime>();
            this.Owner = new Dictionary<string, IVehicle>();
            this.FreePlaces = new SortedDictionary<int, int>();
        }

        public List<IVehiclePark> VehiclePark { get; set; }

        public Dictionary<IVehicle, string> VehicleInPark { get; set; }

        public Dictionary<string, IVehicle> Park { get; set; }

        public Dictionary<string, IVehicle> NumberPlates { get; set; }

        public Dictionary<IVehicle, DateTime> Time { get; set; }

        public Dictionary<string, IVehicle> Owner { get; set; }

        public SortedDictionary<int, int> FreePlaces { get; set; }
    }
}