namespace Srubsko
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SrubskoMain
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

            string inputLine = null;
            while (inputLine != "End")
            {
                inputLine = Console.ReadLine();

                string pattern = @"([a-zA-Z\s]+)\s@([a-zA-Z\s]+)\s(\d+)\s(\d+)";
                
                MatchCollection mathces = Regex.Matches(inputLine, pattern);

                foreach (Match match in mathces)
                {
                    int venuesWords = match.Groups[2].Value.Trim().Split().ToArray().Count();
                    int singersWords = match.Groups[1].Value.Trim().Split().ToArray().Count();
                    if (venuesWords == 0 || venuesWords > 3 || singersWords == 0 || singersWords > 3)
                    {
                        break;
                    }

                    if (!data.ContainsKey(match.Groups[2].Value.Trim()))
                    {
                        data[match.Groups[2].Value.Trim()] = new Dictionary<string, int>();
                    }

                    if (!data[match.Groups[2].Value.Trim()].ContainsKey(match.Groups[1].Value.Trim()))
                    {
                        data[match.Groups[2].Value.Trim()].Add(match.Groups[1].Value.Trim(), 0);
                    }

                    data[match.Groups[2].Value.Trim()][match.Groups[1].Value.Trim()] +=
                    int.Parse(match.Groups[3].Value.Trim()) * int.Parse(match.Groups[4].Value.Trim());
                }
            }

            foreach (var venue in data)
            {
                Console.WriteLine(venue.Key);
                foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("#  {0} -> {1}", singer.Key, singer.Value);
                }
            }
        }
    }
}
