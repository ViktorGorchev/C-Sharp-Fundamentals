namespace BangaloreUniversityLearningSystem
{
    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Core;
    using BangaloreUniversityLearningSystem.Data;

    public class BulsMain
    {
        public static void Main()
        {
            IBangaloreUniversityDate dataBase = new BangaloreUniversityDate();
            IEngine universityEngine = new BangaloreUniversityEngine(dataBase);
            universityEngine.Run();
        }
    }
}