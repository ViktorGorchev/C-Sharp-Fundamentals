namespace TestBoatRacingSimulator
{
    using System;

    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestOpenRaceMethod
    {
        private const int RaceDistance = 100;
        private const int RaceWindSpeed = 10;
        private const int RaceOceanCurrentSpeed = 5;
        private const bool RaceAllowsMotorboats = true;
        private BoatSimulatorDatabase database;
        private IRace race;
        private IBoatSimulatorController controller;

        [TestInitialize]
        public void TestInitialise()
        {
            this.database = new BoatSimulatorDatabase();
            this.controller = new BoatSimulatorController(this.database, this.race);
        }

        [TestMethod]
        public void TestOpenRace_AddRace_ShouldReturnMessage()
        {
            string expeced = String.Format(
                "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                RaceDistance,
                RaceWindSpeed,
                RaceOceanCurrentSpeed);

            var result = this.controller.OpenRace(RaceDistance, RaceWindSpeed, RaceOceanCurrentSpeed, RaceAllowsMotorboats);

            Assert.AreEqual(expeced, result);
        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyExistsException), Constants.RaceAlreadyExistsMessage)]
       public void TestOpenRace_AddSecondRace_ShouldThrow()
        {
            var result1 = this.controller.OpenRace(RaceDistance, RaceWindSpeed, RaceOceanCurrentSpeed, RaceAllowsMotorboats);
            var result2 = this.controller.OpenRace(RaceDistance, RaceWindSpeed, RaceOceanCurrentSpeed, RaceAllowsMotorboats);
        }
    }
}