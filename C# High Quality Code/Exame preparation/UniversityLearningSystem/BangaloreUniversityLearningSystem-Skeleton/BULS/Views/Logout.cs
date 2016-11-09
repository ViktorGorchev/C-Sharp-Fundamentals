namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Utilities;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged out successfully.", (this.Model as User).Usr).AppendLine();
        }
    }
}