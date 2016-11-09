namespace MyRageQuit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class RageQuitMain
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(\D+)(\d+)";
            var matches = Regex.Matches(input, pattern);

            StringBuilder result = new StringBuilder();
            foreach (Match match in matches)
            {
                var text = match.Groups[1].Value;
                int number = int.Parse(match.Groups[2].Value);
                
                for (int i = 0; i < number; i++)
                {
                    result.Append(text.ToUpper());
                }
            }

            Console.WriteLine("Unique symbols used: {0}", result.ToString().Distinct().Count());
            Console.WriteLine(result);
        }
    }
}