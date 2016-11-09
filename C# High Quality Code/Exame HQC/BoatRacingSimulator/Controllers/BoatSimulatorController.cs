namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Enumerations;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;
    using BoatRacingSimulator.Models.BoatEngines;
    using BoatRacingSimulator.Models.Boats;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(BoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController()
            : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public BoatSimulatorDatabase Database { get; private set; }

        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IModel engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetBoatEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveBoatEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.Database.Engines.Add(engine);
            return string.Format(
                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.", 
                model, 
                horsepower, 
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat rowBoat = new RowBoat(model, weight, weight);
            this.Database.Boats.Add(rowBoat);
            
            return string.Format("Row boat with model {0} registered successfully.", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat sailBoat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(sailBoat);
            
            return string.Format("Sail boat with model {0} registered successfully.", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            var firstBoatEngine = this.Database.Engines.GetItem(firstEngineModel) as JetBoatEngine;
            var secondBoatEngine = this.Database.Engines.GetItem(secondEngineModel) as SterndriveBoatEngine;
            IBoat powerBoat = new PowerBoat(model, weight, firstBoatEngine, secondBoatEngine);
            this.Database.Boats.Add(powerBoat);
            
            return string.Format("Power boat with model {0} registered successfully.", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            var boatEngine = this.Database.Engines.GetItem(engineModel) as JetBoatEngine;
            IBoat yacht = new Yacht(model, weight, boatEngine, cargoWeight);
            this.Database.Boats.Add(yacht);
            
            return string.Format("Yacht with model {0} registered successfully.", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;
            return
                string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.", 
                    distance, 
                    windSpeed, 
                    oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            IBoat boat = this.Database.Boats.GetItem(model);
            this.ValidateRaceIsSet();
            if (!this.CurrentRace.AllowsMotorboats && boat.BoatHasMotor)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.CurrentRace.AddParticipant(boat);
            return string.Format("Boat with model {0} has signed up for the current Race.", model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();
            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var first = this.FindFastest(participants);
            participants.Remove(first.Value);
            var second = this.FindFastest(participants);
            participants.Remove(second.Value);
            var third = this.FindFastest(participants);
            participants.Remove(third.Value);

            var result = new StringBuilder();
            result.AppendLine(
                string.Format(
                    "First place: {0} Model: {1} Time: {2}", 
                    first.Value.GetType().Name, 
                    first.Value.Model, 
                    double.IsInfinity(first.Key) ? "Did not finish!" : first.Key.ToString("0.00") + " sec"));
            result.AppendLine(
                string.Format(
                    "Second place: {0} Model: {1} Time: {2}", 
                    second.Value.GetType().Name, 
                    second.Value.Model, 
                    double.IsInfinity(second.Key) ? "Did not finish!" : second.Key.ToString("0.00") + " sec"));
            result.Append(
                string.Format(
                    "Third place: {0} Model: {1} Time: {2}", 
                    third.Value.GetType().Name, 
                    third.Value.Model, 
                    double.IsInfinity(third.Key) ? "Did not finish!" : third.Key.ToString("0.00") + " sec"));

            this.CurrentRace = null;

            return result.ToString();
        }

        public string GetStatistic()
        {
            // TODO Bonus Task Implement me
            throw new NotImplementedException();
        }

        private KeyValuePair<double, IBoat> FindFastest(IList<IBoat> participants)
        {
            double bestTime = 0;
            IBoat winner = null;
            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(this.CurrentRace);
                var time = this.CurrentRace.Distance / speed;
                if (time < bestTime)
                {
                    bestTime = time;
                    winner = participant;
                }
            }

            return new KeyValuePair<double, IBoat>(bestTime, winner);
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}