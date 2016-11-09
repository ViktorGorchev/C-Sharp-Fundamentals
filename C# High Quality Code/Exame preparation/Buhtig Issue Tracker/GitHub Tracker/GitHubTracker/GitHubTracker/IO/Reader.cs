namespace GitHubTracker.IO
{
    using System;
    using GitHubTracker.Contracts;

    public class Reader : IReader
    {
        public string Read()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
