namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;

    using BoatRacingSimulator.Models;

    /// <summary>
    /// Holds the parameters of a race and methods for storing and retrieving information for the participants.
    /// </summary>
    public interface IRace
    {
        /// <summary>
        /// Race distance.
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// Wind speed when the race is opened.
        /// </summary>
        int WindSpeed { get; }

        /// <summary>
        /// Ocean current speed when the race is opened.
        /// </summary>
        int OceanCurrentSpeed { get; }

        /// <summary>
        /// Sets if motor boats are allowed in the race.
        /// </summary>
        bool AllowsMotorboats { get; }

        /// <summary>
        /// Stores participants in the race.
        /// </summary>
        /// <param name="boat">Boat to participate in the race. </param>
        void AddParticipant(IBoat boat);
        
        /// <summary>
        /// Returns all the boats added as participants.
        /// </summary>
        /// <returns>IList holding all the boats added as participants.</returns>
        IList<IBoat> GetParticipants();
    }
}