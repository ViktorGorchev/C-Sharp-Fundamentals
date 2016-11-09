namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private const string CourseDefualthType = "LocalCourse";

        public LocalCourse(string courseName) 
            : base(CourseDefualthType, courseName)
        {
        }

        public LocalCourse(string courseName, string teacherName) 
            : base(CourseDefualthType, courseName, teacherName)
        {
        }

        public LocalCourse(string courseCourseName, string teacherName, IList<string> students) 
            : base(CourseDefualthType, courseCourseName, teacherName, students)
        {
        }

        public string Lab { get; set; }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = " + this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}
