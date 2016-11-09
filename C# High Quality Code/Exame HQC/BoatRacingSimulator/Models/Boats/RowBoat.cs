namespace BoatRacingSimulator.Models.Boats
{
    using BoatRacingSimulator.Interfaces;

    public class RowBoat : Boat
    {
        private int oars;

        public RowBoat(string model, int weight, int oars)
            : base(model, weight)
        {
            this.Oars = oars;
            this.BoatHasMotor = false;
        }

        public int Oars
        {
            get
            {
                return this.oars;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Oars");
                this.oars = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = (this.Oars * 100) - this.Weight + race.OceanCurrentSpeed;
            return speed;
        }
    }
}
