namespace BoatRacingSimulator.Models.Boats
{
    using BoatRacingSimulator.Interfaces;

    public class PowerBoat : Boat
    {
        public PowerBoat(string model, int weight, IBoatEngine firstBoatEngine, IBoatEngine secondBoatEngine)
            : base(model, weight)
        {
            this.FirstBoatEngine = firstBoatEngine;
            this.SecondBoatEngine = secondBoatEngine;
            this.BoatHasMotor = true;
        }

        public IBoatEngine FirstBoatEngine { get; set; }

        public IBoatEngine SecondBoatEngine { get; set; }

        public override double CalculateRaceSpeed(IRace race)
        {
            return this.FirstBoatEngine.Output + this.SecondBoatEngine.Output - this.Weight + (race.OceanCurrentSpeed / 5d);
        }
    }
}
