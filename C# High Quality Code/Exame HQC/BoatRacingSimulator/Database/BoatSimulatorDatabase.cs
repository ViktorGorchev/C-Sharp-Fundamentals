namespace BoatRacingSimulator.Database
{
    using BoatRacingSimulator.Interfaces;
    
    public class BoatSimulatorDatabase : IBoatSimulatorDatabase
    {
        public BoatSimulatorDatabase()
        {
            this.Boats = new Repository<IBoat>();
            this.Engines = new Repository<IModel>();
        }

        public IRepository<IBoat> Boats { get; private set; }

        public IRepository<IModel> Engines { get; private set; }
    }
}