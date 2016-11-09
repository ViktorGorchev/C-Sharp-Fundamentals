namespace BangaloreUniversityLearningSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Holds methods for using a repository.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns all the stored items.
        /// </summary>
        /// <returns>All the stored items as IEnuberuble collection of generic types.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Returns an item by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Stored item.</returns>
        T Get(int id);

        /// <summary>
        /// Adds an item to the repository.
        /// </summary>
        /// <param name="item">Generic type item. </param>
        void Add(T item);
    }
}