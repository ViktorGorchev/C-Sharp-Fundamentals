namespace E4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        private static readonly SortedDictionary<string, SortedDictionary<string, int>> Data =
            new SortedDictionary<string, SortedDictionary<string, int>>(); 

        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "stop")
            {
                var data = ConvertCToSpacesRegex(input).Split('|');
                string team1 = data[0].Trim();
                string team2 = data[1].Trim();
                var score1 = data[2].Trim().Split(':').Select(int.Parse).ToArray();
                var score2 = data[3].Trim().Split(':').Select(int.Parse).ToArray();
                
                int team1Score = score1[0] + score2[1];
                int team2Score = score1[1] + score2[0];

                int team1AwayGoals = score2[1];
                int team2AwayGoals = score1[1];

                if (!Data.ContainsKey(team1))
                {
                    Data[team1] = new SortedDictionary<string, int>();
                }

                if (!Data[team1].ContainsKey(team2))
                {
                    Data[team1].Add(team2, 0);
                }

                if (!Data.ContainsKey(team2))
                {
                    Data[team2] = new SortedDictionary<string, int>();
                }

                if (!Data[team2].ContainsKey(team1))
                {
                    Data[team2].Add(team1, 0);
                }

                if (team1Score == team2Score)
                {
                    if (team1AwayGoals > team2AwayGoals)
                    {
                        Data[team1][team2] += 1;
                    }

                    if (team2AwayGoals > team1AwayGoals)
                    {
                        Data[team2][team1] += 1;
                    }

                    input = Console.ReadLine();
                    continue;
                }
                
                if (team1Score > team2Score)
                {
                    Data[team1][team2] += 1;
                }

                if (team2Score > team1Score)
                {
                    Data[team2][team1] += 1;
                }
                
                input = Console.ReadLine();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var teame in Data.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine(teame.Key);
                Console.WriteLine("- Wins: {0}", teame.Value.Sum(x => x.Value));
                List<string> oponents = new List<string>();
                foreach (var opponent in teame.Value)
                {
                    oponents.Add(opponent.Key);
                }

                Console.WriteLine("- Opponents: {0}", string.Join(", ", oponents));
            }
        }

        private static string ConvertCToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}