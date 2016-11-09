namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Utilities;

    public class AddLecture : View
    {
        public AddLecture(Course course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as Course;
            viewResult.AppendFormat("Lecture successfully added to course {0}.", course.Name).AppendLine();
        }
    }
}