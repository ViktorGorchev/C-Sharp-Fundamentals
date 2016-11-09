namespace VehiclesParkSystemTests
{
    using System;
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

        private const int ParkPlaces = 5;

        private const string LicensePlate = "CA1001HH";

        private const string Owner = "Bob";

        private const int ReservedHouers = 1;

        private Car car;

        private IDataBase dataBase;

        private DateTime starTime;

        private IVehiclePark vehiclePark;

        [TestInitialize]
        public void TestInitialise()
        {
            this.dataBase = new VehicleDataBase();
            this.SeedSectorsAndPlacesToDataBase();
            this.vehiclePark = new VehiclePark(Sectors, ParkPlaces, this.dataBase);
            this.car = new Car(LicensePlate, Owner, ReservedHouers);
            this.starTime = DateTime.Parse("2015-05-04T11:30:00.0000000", null, DateTimeStyles.RoundtripKind);
        }

        [TestMethod]
        public void TestInsertCar_AddCarToPark_ShouldReturnOkString()
        {
            string expectedResult = string.Format(
                "{0} parked successfully at place ({1},{2})", 
                this.car.GetType().Name, 
                Sectors, 
                ParkPlaces);

            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            Assert.AreEqual(expectedResult, result, "Car was not added to the vehicles park database!");
        }

        [TestMethod]
        public void TestInsertCar_AddCarToPark_ShouldAddTheGivenCarParams()
        {
            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            Assert.IsTrue(this.dataBase.Owner.ContainsKey(this.car.Owner), "Owner is not in the database!");
            Assert.AreEqual(
                this.car.LicensePlate, 
                this.dataBase.Owner[this.car.Owner].LicensePlate, 
                "License plate not found!");
            Assert.AreEqual(
                this.car.RegularRate, 
                this.dataBase.Owner[this.car.Owner].RegularRate, 
                "Regular rate plate not found!");
            Assert.AreEqual(
                this.car.OvertimeRate, 
                this.dataBase.Owner[this.car.Owner].OvertimeRate, 
                "Overtime rate plate not found!");
            Assert.AreEqual(
                this.car.ReservedHours, 
                this.dataBase.Owner[this.car.Owner].ReservedHours, 
                "Reserved hours rate plate not found!");
        }

        [TestMethod]
        public void TestInsertCar_AddCarToPark_ShouldAddStartTime()
        {
            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            Assert.AreEqual(this.starTime, this.dataBase.Time[this.car], "Start time dose not match!");
        }

        [TestMethod]
        public void TestInsertCar_AddCarToPark_ShouldAddSectorAndPlace()
        {
            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            string expectedSectorAndPlaceResult = string.Format("({0},{1})", Sectors, ParkPlaces);

            Assert.IsTrue(
                this.dataBase.Park.ContainsKey(expectedSectorAndPlaceResult), 
                "Car dose not have park data in Park database!");
            Assert.AreEqual(
                expectedSectorAndPlaceResult, 
                this.dataBase.VehicleInPark[this.car], 
                "Different sector and/or park place(VehicleInPark database)!");
        }

        [TestMethod]
        public void TestInsertCar_AddCarToPark_ShouldAddCarToGivenSectorAndPlace()
        {
            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            string expectedKey = string.Format("({0},{1})", Sectors, ParkPlaces);

            Assert.AreEqual(
                this.car, 
                this.dataBase.Park[expectedKey], 
                "Different sector and/or park place(Park database)!");
            Assert.IsTrue(
                this.dataBase.VehicleInPark.ContainsKey(this.car), 
                "Car dose not have park data in VehicleInPark database!");
        }

        [TestMethod]
        public void TestInsertCar_AddCarToPark_ShouldAddCarLicensePlate()
        {
            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            Assert.IsTrue(
                this.dataBase.NumberPlates.ContainsKey(this.car.LicensePlate), 
                "Car License Plate not in the NumberPlates database!");
            Assert.AreEqual(
                this.car, 
                this.dataBase.NumberPlates[this.car.LicensePlate], 
                "Car not added in NumberPlates database!");
        }

        [TestMethod]
        public void TestInsertCar_AddCarToPark_ShouldTakeOnePlaceInPark()
        {
            int expectedResult = this.dataBase.FreePlaces[Sectors] - 1;

            string addingResult = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            Assert.AreEqual(expectedResult, this.dataBase.FreePlaces[Sectors], "Car did not take 1 place in park!");
        }

        [TestMethod]
        public void TestInsertCar_AtZeroSector_ShouldReturnNoSector()
        {
            string expectedResult = "There is no sector 0 in the park";

            string result = this.vehiclePark.InsertCar(this.car, 0, ParkPlaces, this.starTime);

            Assert.AreEqual(expectedResult, result, "Car cannot be parked in non existing sector: 0!");
        }

        [TestMethod]
        public void TestInsertCar_AtBiggerThanActualSector_ShouldReturnNoSector()
        {
            int sectorBiggerThanSize = Sectors + 1;
            string expectedResult = string.Format("There is no sector {0} in the park", sectorBiggerThanSize);

            string result = this.vehiclePark.InsertCar(this.car, sectorBiggerThanSize, ParkPlaces, this.starTime);

            Assert.AreEqual(
                expectedResult, 
                result, 
                string.Format("Car cannot be parked in non existing sector: {0}!", sectorBiggerThanSize));
        }

        [TestMethod]
        public void TestInsertCar_AtZeroPlace_ShouldReturnNoPlace()
        {
            string expectedResult = string.Format("There is no place {0} in sector {1}", 0, Sectors);

            string result = this.vehiclePark.InsertCar(this.car, Sectors, 0, this.starTime);

            Assert.AreEqual(expectedResult, result, "Car cannot be parked in non existing park place: 0!");
        }

        [TestMethod]
        public void TestInsertCar_AtBiggerThanActualPlace_ShouldReturnNoPlace()
        {
            int biggerThanActualPlace = ParkPlaces + 1;
            string expectedResult = string.Format("There is no place {0} in sector {1}", biggerThanActualPlace, Sectors);

            string result = this.vehiclePark.InsertCar(this.car, Sectors, biggerThanActualPlace, this.starTime);

            Assert.AreEqual(
                expectedResult, 
                result, 
                string.Format("Car cannot be parked in non existing park place: {0}!", biggerThanActualPlace));
        }

        [TestMethod]
        public void TestInsertCar_CarAddedToTakenPlace_ShouldReturnPlaceOccupied()
        {
            string expectedResult = string.Format("The place ({0},{1}) is occupied", Sectors, ParkPlaces);
            this.dataBase.Park.Add(string.Format("({0},{1})", Sectors, ParkPlaces), this.car);

            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            Assert.AreEqual(expectedResult, result, "Car cannot be parked in occupied park place!");
        }

        [TestMethod]
        public void TestInsertCar_CarLicensePlateAlreadyAdded_ShouldReturnVehicleAlreadyInPark()
        {
            string expectedResult = string.Format(
                "There is already a vehicle with license plate {0} in the park", 
                this.car.LicensePlate);
            this.dataBase.NumberPlates.Add(this.car.LicensePlate, this.car);

            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            Assert.AreEqual(
                expectedResult, 
                result, 
                "Vehicles with the same license plates cannot be added to the park!");
        }

        [TestMethod]
        public void TestInsertCar_CarAddedToFullSector_ShouldReturnNoFreePlaces()
        {
            string expectedResult = string.Format("No free places in sector {0}!", Sectors);
            this.dataBase.FreePlaces[Sectors] -= ParkPlaces;

            string result = this.vehiclePark.InsertCar(this.car, Sectors, ParkPlaces, this.starTime);

            Assert.AreEqual(expectedResult, result, "Vehicle cannot be parked in full sector!");
        }

        private void SeedSectorsAndPlacesToDataBase()
        {
            for (int i = 1; i <= Sectors; i++)
            {
                this.dataBase.FreePlaces[i] = ParkPlaces;
            }
        }
    }
}