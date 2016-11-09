namespace MySoftuniPalatkaConf
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class TentMain
    {
        public static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, int>>();
            data["tents"] = new Dictionary<string, int> { { "normal", 2 }, { "firstClass", 3 } };
            data["rooms"] = new Dictionary<string, int> { { "single", 1 }, { "double", 2 }, { "triple", 3 } };
            data["food"] = new Dictionary<string, int>() { { "musaka", 2 }, { "zakuska", 0 } };

            int people = int.Parse(Console.ReadLine());
            int numberLines = int.Parse(Console.ReadLine());

            int beds = 0;
            int food = 0;
            for (int i = 0; i < numberLines; i++)
            {
                var input = ConvertCToSpacesRegex(Console.ReadLine()).Split();
                string accomudationAndFood = input[0].Trim();
                int numberOfTents = int.Parse(input[1].Trim());
                string type = input[2].Trim();

                switch (accomudationAndFood)
                {
                    case "tents":
                    case "rooms":
                            beds += data[accomudationAndFood][type] * numberOfTents;
                        break;
                    case "food":
                            food += data[accomudationAndFood][type] * numberOfTents;
                        break;
                    default:
                        break;
                }
            }

            if (beds - people < 0)
            {
                Console.WriteLine("Some people are freezing cold. Beds needed: {0}", people - beds);
            }
            else
            {
                Console.WriteLine("Everyone is happy and sleeping well. Beds left: {0}", beds - people);
            }

            if (food - people < 0)
            {
                Console.WriteLine("People are starving. Meals needed: {0}", people - food);
            }
            else
            {
                Console.WriteLine("Nobody left hungry. Meals left: {0}", food - people);
            }
        }

        private static string ConvertCToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}