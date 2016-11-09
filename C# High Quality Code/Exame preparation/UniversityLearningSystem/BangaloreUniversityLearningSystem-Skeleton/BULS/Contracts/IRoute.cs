namespace BangaloreUniversityLearningSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the parameters of the url.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// Holds the controller name.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Holds the action.
        /// </summary>
        string ActionName { get; }
        
            /// <summary>
        /// Stores all the other parameters of the url which are different than controller name and action.
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}