namespace BoatRacingSimulator.Interfaces
{
    public interface IBoat : IModel
    {
        int Weight { get; }

        bool BoatHasMotor { get; }

        double CalculateRaceSpeed(IRace race);
    }
}
