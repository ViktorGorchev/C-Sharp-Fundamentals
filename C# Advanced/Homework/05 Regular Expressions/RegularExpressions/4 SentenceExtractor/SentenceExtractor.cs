namespace _4_SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            string sentance = Console.ReadLine();
            string regex = @"[\w\W]*?\b" + word + @"\b[\w\W]*?[?\.!]";
            var matches = Regex.Matches(sentance, regex);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString().Trim());
            }
        }
    }
}
