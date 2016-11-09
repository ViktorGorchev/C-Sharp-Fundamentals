namespace TestBoatRacingSimulator
{
    using BoatRacingSimulator.Controllers;
    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class MoqTestSignUpBoatMethod
    {
        private const string BoatModel = "Queen Merry";
        private const int RaceDistance = 100;
        private const int RaceWindSpeed = 10;
        private const int RaceOceanCurrentSpeed = 5;
        private const bool RaceAllowsMotorboats = true;
        private Mock<IRepository<IBoat>> repository;
        private Mock<IBoat> motorboat;
        private Mock<BoatSimulatorDatabase> database;
        private Mock<IRace> race;
        private Mock<IBoatSimulatorController> controller;

        [TestInitialize]
        public void TestInitialise()
        {
            this.motorboat = new Mock<IBoat>();
            this.repository = new Mock<IRepository<IBoat>>();
            this.repository.Setup(repo => repo.GetItem(It.IsAny<string>())).Returns(this.motorboat.Object);

            this.database = new Mock<BoatSimulatorDatabase>();
            this.database.Setup(d => d.Boats).Returns(this.repository.Object);

            this.race = new Mock<IRace>();
            this.race.Setup(r => r)
                .Returns(new Race(RaceDistance, RaceWindSpeed, RaceOceanCurrentSpeed, RaceAllowsMotorboats));

            this.controller = new Mock<IBoatSimulatorController>();
            this.controller.Setup(c => c).Returns(new BoatSimulatorController(this.database.Object, this.race.Object));
        }

        [TestMethod]
        [ExpectedException(typeof(NoSetRaceException), Constants.NoSetRaceMessage)]
        public void MoqTestSignUpBoat_SignBoatToNonExistingRace_SouldThrow()
        {
            this.controller.Object.SignUpBoat(BoatModel);
        }
    }
}