namespace Exceptions_Homework
{
    using System;

    public class CSharpExam : Exam
    {
        private const int ScoreMin = 0;
        private const int ScoreMax = 100;

        public int Score { get; }

        public CSharpExam(int score)
        {
            if (score < 0)
            {
                throw new NullReferenceException("C# exam scope can't be less than 0!");
            }

            this.Score = score;
        }

        public override ExamResult Check()
        {
            if (this.Score < ScoreMin || this.Score > ScoreMax)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(this.Score), string.Format("Scope must be min: {0} and max: {1}!", ScoreMin, ScoreMax));
            }

            if (this.Score > 0 && this.Score < 30)
            {
                return new ExamResult(2, "Bad result: nothing done.");
            }
            else if (this.Score >= 30 && this.Score < 60)
            {
                return new ExamResult(4, "Average result.");
            }
            else 
            {
                return new ExamResult(6, "Excellent result.");
            }
        }
    }
}
