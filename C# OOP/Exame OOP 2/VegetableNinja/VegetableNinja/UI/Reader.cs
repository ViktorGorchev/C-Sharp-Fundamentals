namespace VegetableNinja.UI
{
    using System;

    using VegetableNinja.Contracts;

    public class Reader : IReader
    {
        public string Reade()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
