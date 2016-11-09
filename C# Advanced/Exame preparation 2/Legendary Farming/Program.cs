namespace LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        private const int NeededAmount = 250;
        private static readonly Dictionary<string, int> LegendaryItems = new Dictionary<string, int>()
        {
            { "fragments", 0 },
            { "motes", 0 },
            { "shards", 0 },
        };

        private static readonly Dictionary<string, int> Junk = new Dictionary<string, int>();

        public static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                var input = ConvertCToSpacesRegex(Console.ReadLine()).ToLower().Split();
                int amount = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        amount = int.Parse(input[j]);
                        continue;
                    }
                    
                    var type = input[j];
                    if (LegendaryItems.ContainsKey(type))
                    {
                        LegendaryItems[type] += amount;

                        if (CheckForNeededAmount())
                        {
                            Print(type);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        if (!Junk.ContainsKey(type))
                        {
                            Junk[type] = 0;
                        }

                        Junk[type] += amount;
                    }
                }
            }
        }

        private static void Print(string type)
        {
            switch (type)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
                default:
                    break;
            }

            LegendaryItems[type] -= NeededAmount;
            StringBuilder result = new StringBuilder();
            foreach (var item in LegendaryItems.OrderByDescending(x => x.Value))
            {
                result.AppendLine(item.Key + ": " + item.Value);
            }

            foreach (var junkItem in Junk.OrderBy(x => x.Key))
            {
                result.AppendLine(junkItem.Key + ": " + junkItem.Value);
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static bool CheckForNeededAmount()
        {
            return LegendaryItems.Any(item => item.Value >= NeededAmount);
        }

        private static string ConvertCToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}
