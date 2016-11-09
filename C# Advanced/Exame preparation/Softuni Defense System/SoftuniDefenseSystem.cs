namespace MyDefenseSystem
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            ////@"([A-Z][a-z]+)[^a-z]*[^A-Z]*([A-Z][a-z]+[A-Z])\D*(\d+)[L]"
            string pattern = @"([A-Z][a-z]+).*?([A-Z][a-z]*[A-Z]).*?(\d+)[L]";

            int allLiters = 0;
            string input = Console.ReadLine();
            while (input != "OK KoftiShans")
            {
                var matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    string name = match.Groups[1].Value;
                    string alcohol = match.Groups[2].Value.ToLower();
                    int liters = int.Parse(match.Groups[3].Value);

                    Console.WriteLine("{0} brought {1} liters of {2}!", name, liters, alcohol);
                    allLiters += liters;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("{0:F3} softuni liters", (double)allLiters / 1000);
        }
    }
}