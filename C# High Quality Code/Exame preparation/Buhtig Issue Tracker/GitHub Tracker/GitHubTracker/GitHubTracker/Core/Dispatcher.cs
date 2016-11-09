namespace GitHubTracker.Core
{
    using System;

    using GitHubTracker.Contracts;
    using GitHubTracker.GitHubViews;
    using GitHubTracker.Models;

    public class Dispatcher : IDispatcher
    {
        private IIssueTracker tracker;

        public Dispatcher()
            : this(new Views())
        {
        }

        internal Dispatcher(IIssueTracker tracker)
        {
            this.tracker = tracker;
        }
        
        public string DispatchAction(ICommand command)
        {
            switch (command.CommandName)
            {
                case "RegisterUser":
                    return this.tracker.RegisterUser(
                        command.Parameters["username"], 
                        command.Parameters["password"], 
                        command.Parameters["confirmPassword"]);
                case "LoginUser":
                    return this.tracker.LoginUser(command.Parameters["username"], command.Parameters["password"]);
                case "LogoutUser":
                    return this.tracker.LogoutUser();
                case "CreateIssue":
                    return this.tracker.CreateIssue(
                        command.Parameters["title"], 
                        command.Parameters["description"], 
                        (IssuePriority)Enum.Parse(typeof(IssuePriority), command.Parameters["priority"], true), 
                        command.Parameters["tags"].Split( new char[] { '/', '|' }, StringSplitOptions.RemoveEmptyEntries));
                case "RemoveIssue":
                    return this.tracker.RemoveIssue(int.Parse(command.Parameters["id"]));
                case "AddComment":
                    return this.tracker.AddComment(int.Parse(command.Parameters["id"]), command.Parameters["text"]);
                case "MyIssues":
                    return this.tracker.GetMyIssues();
                case "MyComments":
                    return this.tracker.GetMyComments();
                case "Search":
                    return this.tracker.SearchForIssues(command.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", command.CommandName);
            }
        }
    }
}