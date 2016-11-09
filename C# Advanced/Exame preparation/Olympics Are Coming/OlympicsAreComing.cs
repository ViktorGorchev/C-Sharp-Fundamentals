namespace MyOlympicsAreComing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class OlympicsAreComing
    {
        public static void Main()
        {
            

        //    var data = new Dictionary<string, List<string>>();

        //    string input = null;
        //    while (input != "report")
        //    {
        //        input = Console.ReadLine();
        //        ////@"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)\s*\|\s*([a-zA-Z]+)"
        //        ////@"^([a-zA-Z]+|[a-zA-Z]+\s+[a-zA-Z]+)\s*\|\s*([a-zA-Z]+)"
        //        ////@"^([a-zA-Z]+\s*[a-zA-Z]+)\s*\|\s*([a-zA-Z]+\s*[a-zA-Z]+)"
        //        string pattern = @"^([a-zA-Z]+\s*[a-zA-Z]+)\s*\|\s*(([a-zA-Z]+\s*[a-zA-Z]+\s*){1,})";
        //        var matches = Regex.Matches(input, pattern);
        //        foreach (Match match in matches)
        //        {
        //            var tempCountry = match.Groups[2].Value.Trim()
        //                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //            string country = null;
        //            if (tempCountry.Count() > 2)
        //            {
        //                continue;
        //            }

        //            if (tempCountry.Count() > 1)
        //            {
        //                country = tempCountry[0] + " " + tempCountry[1];
        //            }
        //            else
        //            {
        //                country = match.Groups[2].Value.Trim();
        //            }
                    
        //            var tempPlayer = match.Groups[1].Value.Trim()
        //                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //            string player = null;
        //            if (tempPlayer.Count() > 1)
        //            {
        //                player = tempPlayer[0] + " " + tempPlayer[1];
        //            }
        //            else
        //            {
        //                player = match.Groups[1].Value.Trim();
        //            }
                    
        //            if (!data.ContainsKey(country))
        //            {
        //                data[country] = new List<string>();
        //            }

        //            data[country].Add(player);
        //        }
        //    }

        //    foreach (var countyData in data.OrderByDescending(x => x.Value.Count))
        //    {
        //        Console.WriteLine(
        //            "{0} ({1} participants): {2} wins",
        //            countyData.Key,
        //            countyData.Value.Distinct().Count(),
        //            countyData.Value.Count);
        //    }



            var data = new Dictionary<string, List<string>>();

            string input = null;
            while (input != "report")
            {
                input = Console.ReadLine();
                var inputData = input.Split('|').ToArray();
                if (inputData.Count() < 2)
                {
                    continue; 
                }

                var tempCounty = inputData[1].Trim().Split(
                    new char[] { ' ', (char)9 }, StringSplitOptions.RemoveEmptyEntries);
                string country = string.Join(" ", tempCounty);

                var tempPlayer = inputData[0].Trim().Split(
                    new char[] { ' ', (char)9 }, StringSplitOptions.RemoveEmptyEntries);
                string player = string.Join(" ", tempPlayer);

                if (!data.ContainsKey(country))
                {
                    data[country] = new List<string>();
                }

                data[country].Add(player);
            }

            foreach (var countyData in data.OrderByDescending(x => x.Value.Count))
            {
               Console.WriteLine(
                    "{0} ({1} participants): {2} wins",
                    countyData.Key,
                    countyData.Value.Distinct().Count(),
                    countyData.Value.Count);
            }
        }
    }
}
