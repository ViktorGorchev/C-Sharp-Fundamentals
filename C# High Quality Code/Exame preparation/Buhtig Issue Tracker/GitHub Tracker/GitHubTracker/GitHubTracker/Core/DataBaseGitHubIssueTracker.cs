namespace GitHubTracker.Core
{
    using System.Collections.Generic;

    using GitHubTracker.Contracts;
    using GitHubTracker.Models;

    using Wintellect.PowerCollections;

    public class DataBaseGitHubIssueTracker : IDataBaseGitHubIssueTracker
    {
        public DataBaseGitHubIssueTracker()
        {
            this.NextIssueId = 1;
            this.Users_dict = new Dictionary<string, User>();

            this.Issues = new MultiDictionary<Problem, string>(true);
            this.Issues1 = new OrderedDictionary<int, Problem>();
            this.Issues2 = new MultiDictionary<string, Problem>(true);
            this.Issues3 = new MultiDictionary<string, Problem>(true);
            this.Issues4 = new MultiDictionary<string, Problem>(true);

            this.Dict = new MultiDictionary<User, Comment>(true);
            this.Comments = new Dictionary<Comment, User>();
        }

        public int NextIssueId { get; set; }

        public MultiDictionary<Problem, string> Issues { get; set; }

        public MultiDictionary<string, Problem> Issues3 { get; set; }

        public Dictionary<Comment, User> Comments { get; set; }

        public User TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem { get; set; }

        public IDictionary<string, User> Users_dict { get; set; }

        public OrderedDictionary<int, Problem> Issues1 { get; set; }

        public MultiDictionary<string, Problem> Issues2 { get; set; }

        public MultiDictionary<string, Problem> Issues4 { get; set; }

        public MultiDictionary<User, Comment> Dict { get; set; }

        public int AddIssue(Problem p)
        {
            return 0;
        }

        public void RemoveIssue(Problem p)
        {
        }
    }
}