namespace GitHubTracker.IO
{
    using System;

    using GitHubTracker.Contracts;

    public class Renderer : IRenderer
    {
        public void Render(string output)
        {
            Console.WriteLine(output);
        }
    }
}
