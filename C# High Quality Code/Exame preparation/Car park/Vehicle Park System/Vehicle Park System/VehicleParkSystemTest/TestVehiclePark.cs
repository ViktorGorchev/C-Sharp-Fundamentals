namespace VehicleParkSystemTest
{
    using System;
    using System.CodeDom;
    using System.Globalization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Vehicle_Park_System.Contracts;
    using Vehicle_Park_System.DataBase;
    using Vehicle_Park_System.Models;
    using Vehicle_Park_System.Models.Parking;

    [TestClass]
    public class TestVehiclePark
    {
        private const int Sectors = 3;
        private const int ParkPlakes = 5;

        private const string LicensePlate = "CA1001HH";
        private const string Owner = "Bob";
        private const int ReservedHouers = 1;

        private IDataBase dataBase;
        private IVehiclePark vehiclePark;
        private Car car;
        private DateTime starTime;

        [ClassInitialize]
        public void ClassInitialize()
        {
            this.dataBase = new VehicleDataBase();
            this.vehiclePark = new VehiclePark(Sectors, ParkPlakes, this.dataBase);
            this.car = new Car(LicensePlate, Owner, ReservedHouers);
            this.starTime = DateTime.Parse("2015-05-04T11:30:00.0000000", null, DateTimeStyles.RoundtripKind);
        }

        [TestMethod]
        public void TestInsertCar_AtZeroSector_ShouldReturnNoSector()
        {
            const string ExpectedResult = "There is no sector 0 in the park";

            string result = this.vehiclePark.InsertCar(this.car, 0, ParkPlakes, this.starTime);

            Assert.AreEqual(ExpectedResult, result, "Car cannot be parked in non existing sector: 0!");
        }

        //public string InsertVehicle(IVehicle vehicle, int sector, int placeNumber, DateTime startTime)
        //{
        //    string validationResult = this.ValidateInputData(vehicle, sector, placeNumber);
        //    if (validationResult != null)
        //    {
        //        return validationResult;
        //    }

        //    this.dataBase.VehicleInPark[vehicle] = string.Format("({0},{1})", sector, placeNumber);
        //    this.dataBase.Park[string.Format("({0},{1})", sector, placeNumber)] = vehicle;
        //    this.dataBase.NumberPlates[vehicle.LicensePlate] = vehicle;
        //    this.dataBase.Time[vehicle] = startTime;
        //    this.dataBase.Owner[vehicle.Owner] = vehicle;
        //    this.dataBase.FreePlaces[sector] -= 1;

        //    return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, placeNumber);
        //}

        //private string ValidateInputData(IVehicle vehicle, int sector, int placeNumber)
        //{
        //    if (sector > this.NumberOfSectors || sector <= 0)
        //    {
        //        return string.Format("There is no sector {0} in the park", sector);
        //    }

        //    if (placeNumber > this.PlacesPerSector || placeNumber <= 0)
        //    {
        //        return string.Format("There is no place {0} in sector {1}", placeNumber, sector);
        //    }

        //    if (this.dataBase.Park.ContainsKey(string.Format("({0},{1})", sector, placeNumber)))
        //    {
        //        return string.Format("The place ({0},{1}) is occupied", sector, placeNumber);
        //    }

        //    if (this.dataBase.NumberPlates.ContainsKey(vehicle.LicensePlate))
        //    {
        //        return string.Format(
        //            "There is already a vehicle with license plate {0} in the park",
        //            vehicle.LicensePlate);
        //    }

        //    if (this.dataBase.FreePlaces[sector] == 0)
        //    {
        //        return string.Format("No free places in sector {0}!", sector);
        //    }

        //    return null;
        //}
    }
}
