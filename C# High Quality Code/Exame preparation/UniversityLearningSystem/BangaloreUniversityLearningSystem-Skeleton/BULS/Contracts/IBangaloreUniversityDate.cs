namespace BangaloreUniversityLearningSystem.Contracts
{
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Utilities;

    public interface IBangaloreUniversityDate
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}