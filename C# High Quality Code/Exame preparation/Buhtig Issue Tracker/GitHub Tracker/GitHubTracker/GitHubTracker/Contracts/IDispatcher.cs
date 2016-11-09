namespace GitHubTracker.Contracts
{
    public interface IDispatcher
    {
        string DispatchAction(ICommand command);
    }
}