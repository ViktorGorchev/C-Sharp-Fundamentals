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
    public class TestStartRaceMethod
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
        [ExpectedException(typeof(NoSetRaceException), Constants.NoSetRaceMessage)]
        public void TestStartRace_NoRaceSetRace_ShouldThrow()
        {
            this.controller.StartRace();
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientContestantsException), Constants.InsufficientContestantsMessage)]
        public void TestStartRace_NoParticipants_ShouldThrow()
        {
            this.controller.OpenRace(RaceDistance, RaceWindSpeed, RaceOceanCurrentSpeed, RaceAllowsMotorboats);
            this.controller.StartRace();
        }
    }
}