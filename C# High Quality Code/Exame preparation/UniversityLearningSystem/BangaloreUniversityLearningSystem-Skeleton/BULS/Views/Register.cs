namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Utilities;

    public class Register : View
    {
        public Register(User user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} registered successfully.", (this.Model as User).Usr).AppendLine();
        }
    }
}