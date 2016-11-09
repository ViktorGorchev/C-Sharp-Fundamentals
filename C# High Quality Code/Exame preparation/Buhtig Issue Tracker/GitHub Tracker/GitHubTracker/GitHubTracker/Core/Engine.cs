namespace GitHubTracker.Core
{
    using System;

    using GitHubTracker.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IRenderer renderer;
        private readonly IDispatcher dispatcher;
        private readonly ICommand command;

        public Engine(IReader reader, IRenderer renderer, ICommand command, IDispatcher dispatcher)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.command = command;
            this.dispatcher = dispatcher;
        }
        
        public void Run()
        {
            while (true)
            {
                string url = this.reader.Read();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (string.IsNullOrEmpty(url))
                {
                    continue;
                }

                try
                {
                    this.command.ExecuteCommand(url);
                    string viewResult = this.dispatcher.DispatchAction(this.command);
                    this.renderer.Render(viewResult);
                }
                catch (Exception ex)
                {
                    this.renderer.Render(ex.Message);
                }
            }
        }
    }
}