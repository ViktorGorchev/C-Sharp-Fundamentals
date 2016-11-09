namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string courseType;
        private string courseName;
        private string teacherName;
        private IList<string> students;
        
        protected Course(string courseType, string courseName)
        {
            this.CourseType = courseType;
            this.CourseName = courseName;
            this.Students = new List<string>();
        }

        protected Course(string courseType, string courseName, string teacherName)
        {
            this.CourseType = courseType;
            this.CourseName = courseName;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        protected Course(string courseType, string courseCourseName, string teacherName, IList<string> students)
        {
            this.CourseType = courseType;
            this.CourseName = courseCourseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string CourseType
        {
            get
            {
                return this.courseType;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                   throw new AggregateException("Coure typecannot be null or empty!");
                }

                this.courseType = value;
            }
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("CourseName cannot be null or empty!");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Teacher name cannot be null or empty!");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students { get; set; }

        private string GetStudentsAsString()
        {
            if (this.Students.Count == 0)
            {
                return "N/A";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.CourseType + " { courseName = " + this.CourseName);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = " + this.TeacherName);
            }

            result.Append("; Students = " + this.GetStudentsAsString());
           
            return result.ToString();
        }
    }
}
