namespace E3
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        private const int numberAsciiDifference = 32;
        private static readonly StringBuilder Result = new StringBuilder();
        private static int lineCount = 1;

        public static void Main()
        {
            string allCommandPatern = @"[<]\s*(.*?)\s*[\/][>]";   ////Trim
            string commandPatern = @"^(.*?)\s+"; ////Trim
            string dataToExecuteCommand = @"""(.*?)"""; ////Trim

            string input = Console.ReadLine();
            while (true)
            {
                var allComandMatches = Regex.Matches(input, allCommandPatern);
                foreach (Match allCommand in allComandMatches)
                {
                    var command = Regex.Match(allCommand.Groups[1].Value.Trim(), commandPatern).Groups[1].Value.Trim();
                    var dataToExecute = Regex.Matches(allCommand.Groups[1].Value.Trim(), dataToExecuteCommand);//////
                    ExecuteCommand(command, dataToExecute);
                }

                input = Console.ReadLine();
            }
        }

        private static void ExecuteCommand(string command, MatchCollection dataToExecute)
        {
            
            switch (command)
            {
                case "inverse":
                    string input = null;
                    foreach (Match data in dataToExecute)
                    {
                        input = data.Groups[1].Value;
                    }

                    InveseInput(input);
                    break;
                case "reverse":
                    foreach (Match data in dataToExecute)
                    {
                        Result.AppendLine(lineCount + ". " + ReverseString(data.Groups[1].Value));
                        lineCount++;
                    }

                    break;
                case "repeat":
                    int repeatCount = 0;
                    string dataToRepeat = null;
                    int count = 0;
                    foreach (Match data in dataToExecute)
                    {
                        if (count == 0)
                        {
                            repeatCount = int.Parse(data.Groups[1].Value);
                            count++;
                            continue;
                        }

                        dataToRepeat = data.Groups[1].Value;
                    }

                    for (int i = 0; i < repeatCount; i++)
                    {
                        Result.AppendLine(lineCount + ". " + dataToRepeat);
                        lineCount++;
                    }

                    break;
                case "":
                    Console.WriteLine(Result.ToString().Trim());
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void InveseInput(string input)
        {
            StringBuilder inversedInput = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char synbol = input[i];
                bool upperCase = (int)synbol > 64 && (int)synbol < 91;
                bool lowerCase = (int)synbol > 96 && (int)synbol < 123;
                if (upperCase)
                {
                    synbol = (char)((int)synbol + numberAsciiDifference);
                }

                if (lowerCase)
                {
                    synbol = (char)((int)synbol - numberAsciiDifference);
                }

                inversedInput.Append(synbol.ToString());
            }

            Result.AppendLine(lineCount + ". " + inversedInput);
            lineCount++;
        }

        private static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
