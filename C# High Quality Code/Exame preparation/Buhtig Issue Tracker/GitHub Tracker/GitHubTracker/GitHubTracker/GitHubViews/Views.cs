namespace GitHubTracker.GitHubViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GitHubTracker.Contracts;
    using GitHubTracker.Core;
    using GitHubTracker.Models;

    public class Views : IIssueTracker
    {
        private DataBaseGitHubIssueTracker data;

        public Views()
            : this(new DataBaseGitHubIssueTracker())
        {
        }

        private Views(IDataBaseGitHubIssueTracker data)
        {
            this.data = data as DataBaseGitHubIssueTracker;
        }
        
        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem != null)
            {
                return "There is already a logged in user";
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }

            if (this.data.Users_dict.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.data.Users_dict.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem != null)
            {
                return "There is already a logged in user";
            }

            if (!this.data.Users_dict.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.data.Users_dict[username];
            if (user.Password != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
            {
                return "There is no currently logged in user";
            }

            string username = this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.UserName;
            this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            if (this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
            {
                return "There is no currently logged in user";
            }

            var issue = new Problem(title, description, priority, tags.Distinct().ToList());
            issue.Id = this.data.NextIssueId;
            this.data.Issues1.Add(issue.Id, issue);
            this.data.NextIssueId++;
            this.data.Issues2[this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.UserName].Add(
                issue);

            //// PERFORMANCE: There in no need for adding the same object Problem to each tag.
            foreach (var tag in issue.Tags)
            {
                this.data.Issues4[tag].Add(issue);
            }

            return string.Format("Issue {0} created successfully.", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.data.Issues1.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.data.Issues1[issueId];
            if (!this.data.Issues2[this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.UserName].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}", 
                    issueId, 
                    this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.UserName);
            }

            this.data.Issues2[this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.UserName].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.data.Issues4[tag].Remove(issue);
            }

            this.data.Issues1.Remove(issue.Id);
            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int intValue, string stringValue)
        {
            if (this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.data.Issues1.ContainsKey(intValue - 1))
            {
                return string.Format("There is no issue with ID {0}", intValue - 1);
            }

            var issue = this.data.Issues1[intValue];
            var comment = new Comment(this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem, stringValue);
            issue.AddComment(comment);
            this.data.Dict[this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
            {
                return "There is no currently logged in user";
            }

            var issues =
                this.data.Issues2[this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.UserName];
            var newIssues = issues;
            if (!newIssues.Any())
            {
                var result = string.Empty;
                foreach (var i in this.data.Issues2)
                {
                    result += i.Value.Select(iss => iss.Comments.Select(c => c.Text)).ToString();
                }

                return "No issues";
            }

            return string.Join(Environment.NewLine, newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments()
        {
            if (this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem == null)
            {
                return "There is no currently logged in user";
            }

            var comments = new List<Comment>();
            this.data.Issues1.Select(i => i.Value.Comments).ToList().ForEach(item => comments.AddRange(item));
            var resultComments =
                comments.Where(
                    c =>
                    c.Author.UserName
                    == this.data.TheUserWhichHasCurrentlyLoggedIntoTheIssueTrackingSystem.UserName).ToList();
            var strings = resultComments.Select(x => x.ToString());
            if (!strings.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, strings);
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length < 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Problem>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.data.Issues4[tag]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            //var distinctIssues = issues.Distinct();
            //if (!distinctIssues.Any())
            //{
            //    return "No issues";
            //}

            return string.Join(
                Environment.NewLine, 
                issues.Distinct()
                .OrderByDescending(x => x.Priority)
                .ThenBy(x => x.Title));
        }
    }
}