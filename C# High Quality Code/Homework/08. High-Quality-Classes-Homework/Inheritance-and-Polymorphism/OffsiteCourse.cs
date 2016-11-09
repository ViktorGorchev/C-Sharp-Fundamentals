namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private const string CourseDefualthType = "OffsiteCourse";

        public OffsiteCourse(string courseName) 
            : base(CourseDefualthType, courseName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName) 
            : base(CourseDefualthType, courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseCourseName, string teacherName, IList<string> students) 
            : base(CourseDefualthType, courseCourseName, teacherName, students)
        {
        }

        public string Town { get; set; }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = " + this.Town);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}
