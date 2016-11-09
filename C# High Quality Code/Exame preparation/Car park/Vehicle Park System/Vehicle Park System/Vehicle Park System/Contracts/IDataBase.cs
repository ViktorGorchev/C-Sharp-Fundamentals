namespace Vehicle_Park_System.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IDataBase
    {
        List<IVehiclePark> VehiclePark { get; set; }

        Dictionary<IVehicle, string> VehicleInPark { get; set; }

        Dictionary<string, IVehicle> Park { get; set; }

        Dictionary<string, IVehicle> NumberPlates { get; set; }

        Dictionary<IVehicle, DateTime> Time { get; set; }

        Dictionary<string, IVehicle> Owner { get; set; }

        SortedDictionary<int, int> FreePlaces { get; set; }
    }
}
