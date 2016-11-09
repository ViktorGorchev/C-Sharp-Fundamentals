namespace _6_CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var chars = new SortedDictionary<char, int>();
            foreach (var symbol in input)
            {
                if (chars.ContainsKey(symbol))
                {
                    chars[symbol]++;
                }
                else
                {
                    chars[symbol] = 1;
                }
            }

            foreach (var pair in chars)
            {
                Console.WriteLine("{0} : {1} time/s", pair.Key, pair.Value);
            }
        }
    }
}
