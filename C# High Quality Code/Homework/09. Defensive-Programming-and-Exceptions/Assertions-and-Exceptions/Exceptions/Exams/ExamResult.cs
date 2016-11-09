namespace Exceptions_Homework
{
    using System;

    public class ExamResult
    {
        public readonly int MinGrade = 2;
        public readonly int MaxGrade = 6;

        private int grade;
        private string comments;

        public ExamResult(int grade, string comments)
        {
            this.Grade = grade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value < this.MinGrade || value > this.MaxGrade)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), string.Format("Grade can be min: {0} and max: {1}", this.MinGrade, this.MaxGrade));
                }

                this.grade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Coments can't be null or empty!");
                }

                this.comments = value;
            }
        }
    }
}
