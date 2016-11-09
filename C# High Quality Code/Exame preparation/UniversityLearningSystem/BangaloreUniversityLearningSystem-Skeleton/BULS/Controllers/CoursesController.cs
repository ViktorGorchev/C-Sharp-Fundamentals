namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Utilities;

    internal class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDate data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer) && !this.User.IsInRole(Role.Student))
            {
                throw new AggregateException("The current user is not authorized to perform this operation.");
            }
            
            if (this.CourseDoesNotExist(courseId))
            {
                throw new AggregateException(string.Format("There is no course with ID {0}.", courseId));
            }

            if (!this.UserEnrolledInCourse(courseId))
            {
                throw new AggregateException("You are not enrolled in this course.");
            }

            Course course = this.Data.Courses.Get(courseId);
            return this.View(course);
        }

        public IView Enroll(int id)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var c = this.Data.Courses.Get(id);
            if (c == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", id));
            }

            if (this.User.Courses.Contains(c))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            c.AddStudent(this.User);
            return this.View(c);
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new AggregateException("The current user is not authorized to perform this operation.");
            }

            var c = new Course(name);
            this.Data.Courses.Add(c);
            return this.View(c);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new AggregateException("The current user is not authorized to perform this operation.");
            }

            Course c = this.CourseGetter(courseId);
            c.AddLecture(new Lecture(lectureName));
            return this.View(c);
        }

        private Course CourseGetter(int c_id)
        {
            var course = this.Data.Courses.Get(c_id);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", c_id));
            }

            return course;
        }

        private bool CourseDoesNotExist(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                return true;
            }

            return false;
        }

        private bool UserEnrolledInCourse(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            bool result = this.User.Courses.Contains(course);

            return result;
        }
    }
}