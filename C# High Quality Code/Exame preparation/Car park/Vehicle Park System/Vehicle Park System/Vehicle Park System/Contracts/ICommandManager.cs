namespace Vehicle_Park_System.Contracts
{
    using System.Collections.Generic;

    internal interface ICommandManager
    {
        string ExecuteCommand(string commandLine);
    }
}
