namespace _2_ReplaceTag
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceTag
    {
        public static void Main()
        {
            string html = Console.ReadLine();
            string regex = @"([\s\S]*?)<a([\s\S]*?)>([\s\S]*?)<\/a>([\s\S]*)";
            var data = Regex.Matches(html, regex);
            foreach (Match match in data)
            {
                Console.WriteLine(match.Groups[1] + "[URL" + match.Groups[2] + "]" +
                    match.Groups[3] + "[/URL]");
            }
        }
    }
}
