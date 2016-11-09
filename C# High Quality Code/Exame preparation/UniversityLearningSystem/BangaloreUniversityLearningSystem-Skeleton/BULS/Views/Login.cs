namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Utilities;

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged in successfully.", (this.Model as User).Usr).AppendLine();
        }
    }
}