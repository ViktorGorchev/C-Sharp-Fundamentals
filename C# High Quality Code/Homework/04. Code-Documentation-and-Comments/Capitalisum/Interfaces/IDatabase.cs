namespace ExamPreparationCapitalism.Interfaces
{
    using System.Collections.Generic;
    using Models.Interfaces;

    /// <summary>
    /// Defines the database and its main components.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Gets all the companies in the database. 
        /// </summary>
        IEnumerable<IOrganizationalUnit> Companies { get; }

        /// <summary>
        /// Method for adding a company in the companies archive.
        /// </summary>
        /// <param name="company">Company to add.</param>
        void AddCompany(IOrganizationalUnit company);
    }
}
