namespace E4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, List<string>>>();
            string pattern = @"#([A-Za-z]+):\s*@([A-Za-z]+)\s*(\d{1,2}):(\d{1,2})";

            int linesNumber = int.Parse(Console.ReadLine().Trim());

            for (int i = 0; i < linesNumber; i++)
            {
                var input = Console.ReadLine();
                var matches = Regex.Matches(input, pattern);

                foreach (Match match in matches)
                {
                    string location = match.Groups[2].Value;
                    string persone = match.Groups[1].Value;
                    string houerString = match.Groups[3].Value;
                    string minutesString = match.Groups[4].Value;

                    int houer = int.Parse(houerString);
                    int minutes = int.Parse(minutesString);

                    bool houersInRange = houer >= 0 && houer < 24;
                    bool minutesInRange = minutes >= 0 && minutes < 60;
                    if (!houersInRange || !minutesInRange)
                    {
                        continue;
                    }

                    if (!data.ContainsKey(location))
                    {
                        data[location] = new Dictionary<string, List<string>>();
                    }

                    if (!data[location].ContainsKey(persone))
                    {
                        data[location].Add(persone, new List<string>());
                    }

                    string zeroHouer = string.Empty;
                    string zeroMinutes = string.Empty;
                    if (houerString.Length < 2)
                    {
                        zeroHouer = "0";
                    }

                    if (minutesString.Length < 2)
                    {
                        zeroMinutes = "0";
                    }

                    data[location][persone].Add(zeroHouer + houerString + ":" + zeroMinutes + minutesString);
                }
            }

            var towns = Console.ReadLine().Trim().Split(',').ToList();
            towns.Sort();
            
            foreach (var town in towns)
            {
                if (!data.ContainsKey(town))
                {
                    continue;
                }

                Console.WriteLine(town + ":");
                int count = 1;
                foreach (var name in data[town].OrderBy(x => x.Key))
                {
                    name.Value.Sort();
                    Console.WriteLine("{0}. {1} -> {2}", count, name.Key, string.Join(", ", name.Value));
                    count++;
                }
            }
        }
    }
}
