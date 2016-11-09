namespace GitHubTracker.Contracts
{
    using System.Collections.Generic;

    using GitHubTracker.Models;

    using Wintellect.PowerCollections;

    internal interface IDataBaseGitHubIssueTracker
    {
        User TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem { get; set; }

        IDictionary<string, User> Users_dict { get; }

        OrderedDictionary<int, Problem> Issues1 { get; }

        MultiDictionary<string, Problem> Issues2 { get; }

        MultiDictionary<string, Problem> Issues4 { get; }

        MultiDictionary<User, Comment> Dict { get; }

        int AddIssue(Problem p);

        void RemoveIssue(Problem p);
    }
}