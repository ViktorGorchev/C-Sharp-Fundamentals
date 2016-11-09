namespace Theatre.UI
{
    using System;

    using Theatre.Contracts;

    public class Reader : IReader
    {
        public string Read()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
