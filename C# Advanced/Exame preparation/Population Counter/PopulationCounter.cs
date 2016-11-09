namespace MyPopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class PopulationCounter
    {
        public static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while (input != "report")
            {
                var inputInfo = ConvertCToSpacesRegex(input).Split('|');
                string country = inputInfo[1].Trim();
                string city = inputInfo[0].Trim();
                long population = long.Parse(inputInfo[2].Trim());

                if (!data.ContainsKey(country))
                {
                    data[country] = new Dictionary<string, long>();
                }

                data[country].Add(city, population);

                input = Console.ReadLine();
            }

            foreach (var country in data.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine("{0} (total population: {1})", country.Key, country.Value.Values.Sum());
                foreach (var city in country.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                }
            }
        }

        private static string ConvertCToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}
