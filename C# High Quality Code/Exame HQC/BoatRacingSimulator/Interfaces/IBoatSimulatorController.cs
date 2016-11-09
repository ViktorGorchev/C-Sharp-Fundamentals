namespace BoatRacingSimulator.Interfaces
{
    using System;

    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Enumerations;

    public interface IBoatSimulatorController
    {
        IRace CurrentRace { get; }

        BoatSimulatorDatabase Database { get; }

        /// <summary>
        /// Creates a boat engine.
        /// </summary>
        /// <param name="model">Model of the engine in string format.</param>
        /// <param name="horsepower">Horsepower of the engine in int format.</param>
        /// <param name="displacement">Displacement of the engine in int format.</param>
        /// <param name="engineType">Type of the engine to be created.</param>
        /// <returns>Confirmation message in string format showing the parameters of the created engine.</returns>
        string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType);

        string CreateRowBoat(string model, int weight, int oars);

        string CreateSailBoat(string model, int weight, int sailEfficiency);

        string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel);

        string CreateYacht(string model, int weight, string engineModel, int cargoWeight);

        string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats);

        /// <summary>
        /// Sings up an already created boat to the current race.
        /// </summary>
        /// <param name="model">Model of the boat in string format.</param>
        /// <returns>String message showing that the boat was added to the race.</returns>
        /// <exception cref="ArgumentException">If the boat type is not allowed in the race 
        /// an ArgumentException is thrown.</exception>
        string SignUpBoat(string model);

        string StartRace();

        string GetStatistic();
    }
}