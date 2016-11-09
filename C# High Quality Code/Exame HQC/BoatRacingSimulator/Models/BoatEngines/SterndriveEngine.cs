namespace BoatRacingSimulator.Models.BoatEngines
{
    public class SterndriveBoatEngine : BoatEngine
    {
        private const int Multiplier = 7;

        public SterndriveBoatEngine(string model, int horsepower, int displacement)
            : base(model, horsepower, displacement)
        {
        }

        public override int Output
        {
            get
            {
               return (this.Horsepower * Multiplier) + this.Displacement;
            }
        }
    }
}