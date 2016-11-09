namespace Theatre.Contracts
{
    using System;
    using System.Collections.Generic;

    using Theatre.Models;

    /// <summary>
    /// Controls the adding and reading from the theatres database.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Add's a theatre.
        /// </summary>
        /// <param name="theatreName">String representation of the theatre name.</param>
        /// <exeption>If the theatre already exists throws DuplicateTheatreException!</exeption>
        void AddTheatre(string theatreName);
       
        /// <summary>
        /// Returns the theatres added in the database.
        /// </summary>
        /// <returns>Collection of type IEnumerable containing all the theatres added in the database.</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Add's a performance to a theatre. The theatre must be added first.
        /// </summary>
        /// <param name="theatreName">String representation of the theatre name.</param>
        /// <param name="performanceTitle">String representation of the performace title.</param>
        /// <param name="startDateTime">Stat date and time of the performance</param>
        /// <param name="duration">Duration of the performance.</param>
        /// <param name="price">Ticket price.</param>
        /// <exception>If the theatre is not added before the adding of the performance 
        /// an exception TheatreNotFoundException is thrown!</exception>
        void AddPerformance(
            string theatreName,
            string performanceTitle,
            DateTime startDateTime,
            TimeSpan duration,
            decimal price);

        /// <summary>
        /// Returns all the performances in all the theatres added in the database.
        /// </summary>
        /// <returns>Collection of type IEnumerable containing 
        /// all performances in all the theatres added in the database.</returns>
        IEnumerable<TheatrePerformance> ListAllPerformances();

        /// <summary>
        /// Returns all the performances in a specified theatre.
        /// </summary>
        /// <param name="theatreName">String representation of the theatre name.</param>
        /// <returns>Collection of type IEnumerable containing all the performances 
        /// in the specified theatre added in the database.</returns>
        IEnumerable<TheatrePerformance> ListPerformances(string theatreName);
    }
}
