namespace BoatRacingSimulator.Models.BoatEngines
{
    public class JetBoatEngine : BoatEngine
    {
        private const int Multiplier = 5;

        public JetBoatEngine(string model, int horsepower, int displacement)
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