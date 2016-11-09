namespace Exceptions_Homework
{
    using System;

    public class SimpleMathExam : Exam
    {
        private const int ProblemsMin = 0;
        private const int ProblemsMax = 10;

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            set
            {
                if (value < ProblemsMin)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), string.Format("Problems solved cannot be less than {0}!", ProblemsMin));
                }

                if (value > ProblemsMax)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), string.Format("Problems solved cannot be more than {0}!", ProblemsMax));
                }

                this.problemsSolved = value;
            }
        }
        
        public override ExamResult Check()
        {
            if (this.ProblemsSolved == 0)
            {
                return new ExamResult(2, "Bad result: nothing done.");
            }
            else if (this.ProblemsSolved == 1)
            {
                return new ExamResult(4, "Average result: 1 proble done.");
            }
            else 
            {
                return new ExamResult(6, "Excellent result");
            }
        }
    }
}
