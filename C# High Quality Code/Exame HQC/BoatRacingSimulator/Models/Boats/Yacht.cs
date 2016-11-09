namespace BoatRacingSimulator.Models.Boats
{
    using BoatRacingSimulator.Interfaces;

    public class Yacht : Boat
    {
        private int cargoWeight;

        public Yacht(string model, int weight, IBoatEngine boatEngine, int cargoWeight)
            : base(model, weight)
        {
            this.BoatEngine = boatEngine;
            this.CargoWeight = cargoWeight;
            this.BoatHasMotor = true;
        }

        public IBoatEngine BoatEngine { get; set; }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.BoatEngine.Output - this.Weight - this.CargoWeight + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}
