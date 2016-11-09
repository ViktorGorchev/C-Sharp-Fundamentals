namespace GitHubTracker
{
    using System.Globalization;
    using System.Threading;

    using GitHubTracker.Contracts;
    using GitHubTracker.Core;
    using GitHubTracker.GitHubViews;
    using GitHubTracker.IO;

    internal class GitHubMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IReader reader = new Reader();
            IRenderer renderer = new Renderer();
            IIssueTracker issueTracker = new Views();
            ICommand command = new Command();
            IDispatcher dispatcher = new Dispatcher(issueTracker);

            IEngine engine = new Engine(reader, renderer, command, dispatcher);
            engine.Run();
        }
    }
}