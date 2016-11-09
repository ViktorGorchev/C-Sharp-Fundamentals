namespace _1_SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class SeriesOfLetters
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            foreach (var ch in input)
            {
                Regex regex = new Regex(ch + "+");
                input = regex.Replace(input, ch.ToString());
            }

            Console.WriteLine(input);
        }
    }
}
