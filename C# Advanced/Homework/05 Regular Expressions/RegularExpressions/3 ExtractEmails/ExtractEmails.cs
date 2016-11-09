namespace _3_ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmails
    {
        public static void Main()
        {
            string text = Console.ReadLine();

            string pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@(?:[a-z]+\-?[a-z]+\.)+[a-z]+\-?[a-z]+)\b";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(text);

            foreach (Match email in matches)
            {
                Console.WriteLine(email.Groups[1]);
            }
        }
    }
}
