namespace Vehicle_Park_System.Contracts
{
    internal interface IUserInterface
    {
        string ReadLine();

        void WriteLine(string format, params string[] args);
    }
}