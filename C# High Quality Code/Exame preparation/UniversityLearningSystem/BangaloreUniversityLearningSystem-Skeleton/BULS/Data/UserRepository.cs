namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Utilities;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> usersByUsername;

        public User GetByUsername(string username)
        {
            var user = this.GetAll().FirstOrDefault(u => u.Usr == username);

            return user;
        }
    }
}