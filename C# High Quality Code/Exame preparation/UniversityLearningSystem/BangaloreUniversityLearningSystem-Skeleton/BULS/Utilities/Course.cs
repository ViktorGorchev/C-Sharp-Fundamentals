namespace BangaloreUniversityLearningSystem.Utilities
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private string name;

        public Course(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 5)
            {
                string message = "The course name must be at least 5 symbols long.";
                throw new ArgumentException(message);
            }

            this.Name = name;
            this.Lectures = new List<Lecture>();
            this.Students = new List<User>();
        }

        public string Name { get; set; }

        public IList<Lecture> Lectures { get; set; }

        public IList<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }
    }
}