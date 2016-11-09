namespace GitHubTracker.Contracts
{
    using GitHubTracker.Models;

    /// <summary>
    /// Holds a set of method which aim execute commands given by the user.
    /// </summary>
    internal interface IIssueTracker
    {
        /// <summary>
        /// Performs the registration of the user
        /// </summary>
        /// <param name="username">User name to register.</param>
        /// <param name="password">User password.</param>
        /// <param name="confirmPassword">Confirmed password.</param>
        /// <returns>String result of the registration.</returns>
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        /// Logs in a registered user.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">User password.</param>
        /// <returns>String result of logging in.</returns>
        string LoginUser(string username, string password);

        /// <summary>
        /// Logs out the logged in user.
        /// </summary>
        /// <returns>String result of logout.</returns>
        string LogoutUser();

        /// <summary>
        /// Creates an issue.
        /// </summary>
        /// <param name="title">Issue title.</param>
        /// <param name="description">Issue description.</param>
        /// <param name="priority">Issue priority.</param>
        /// <param name="tags">Issue tags.</param>
        /// <returns>String result of creating issue.</returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        /// Removes an existing issue by its ID.
        /// </summary>
        /// <param name="issueId">Issue ID</param>
        /// <returns>String result of removing issue.</returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// Adds a comment to an issue.
        /// </summary>
        /// <param name="issueId">Issue ID.</param>
        /// <param name="text">Comment.</param>
        /// <returns>String result of the adding.</returns>
        string AddComment(int issueId, string text);

        /// <summary>
        /// Gets all the added issues.
        /// </summary>
        /// <returns>String of all the issues ordered by priority.</returns>
        string GetMyIssues();

        /// <summary>
        /// Gets all the comments by the user.
        /// </summary>
        /// <returns>String of all the added comments by the user.</returns>
        string GetMyComments();

        /// <summary>
        /// Searches for issues array of tags.
        /// </summary>
        /// <param name="tags">Array of tags.</param>
        /// <returns>String of issues ordered by priority.</returns>
        string SearchForIssues(string[] tags);
    }
}