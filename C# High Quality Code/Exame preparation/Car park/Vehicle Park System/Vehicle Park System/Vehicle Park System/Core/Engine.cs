namespace Vehicle_Park_System.Core
{
    using System;

    using Vehicle_Park_System.Contracts;

    internal class Engine : IEngine
    {
        private readonly IUserInterface userInterface;
        private readonly ICommandManager commandManager;

        public Engine(IUserInterface userInterface, ICommandManager commandManager)
        {
            this.userInterface = userInterface;
            this.commandManager = commandManager;
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.userInterface.ReadLine();
                if (commandLine == null || commandLine == "end")
                {
                    break;
                }

                if (string.IsNullOrEmpty(commandLine))
                {
                    continue;
                }

                try
                {
                    string commandResult = this.commandManager.ExecuteCommand(commandLine.Trim());
                    this.userInterface.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
            }
        }
    }
}