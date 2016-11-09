namespace BangaloreUniversityLearningSystem.Utilities
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        private string passwordHash;

        private string username;

        public User(string username, string password, Role role)
        {
            this.Usr = username;
            if (username == null || username == string.Empty)
            {
                string message = "The username must be at least 5 symbols long.";
                throw new ArgumentException(message);
            }

            if (username.Length < 5)
            {
                string message = "The username must be at least 5 symbols long.";
                throw new ArgumentException(message);
            }

            this.Usr = username;
            if (password == null || password == string.Empty)
            {
                string message = "The password must be at least 6 symbols long.";
                throw new ArgumentException(message);
            }

            if (password.Length < 6)
            {
                string message = "The password must be at least 6 symbols long.";
                throw new ArgumentException(message);
            }

            string passwordHash = HashUtilities.HashPassword(password);
            this.Pwd = passwordHash;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Usr { get; set; }

        public string Pwd { get; set; }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}