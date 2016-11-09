namespace BoatRacingSimulator
{
    using BoatRacingSimulator.Core;
    using BoatRacingSimulator.Interfaces;

    public class SimulatorMain
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}