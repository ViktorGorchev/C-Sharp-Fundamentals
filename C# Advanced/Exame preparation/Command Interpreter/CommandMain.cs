namespace CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CommandMain
    {
        private static string[] collection = null;
 
        public static void Main()
        {
            var inputCollection = Console.ReadLine().Trim();
            collection = ConvertWhitespaceToSpacesRegex(inputCollection).Split().ToArray();

            while (true)
            {
                string input = Console.ReadLine().Trim();
                var inputCommand = ConvertWhitespaceToSpacesRegex(input).Split();
                ExecuteCommand(inputCommand);
            }
        }

        private static void ExecuteCommand(string[] inputCommand)
        {
            var command = inputCommand[0];
            var commandParams = inputCommand.Skip(1).ToArray();
            
            switch (command)
            {
                case "reverse":
                    int startIndex = int.Parse(commandParams[1]); 
                    int count = int.Parse(commandParams[3]);
                    if (DataIsCorrect(count, startIndex))
                    {
                        Array.Reverse(collection, startIndex, count);
                    }
                    
                    break;
                case "sort":
                    int sortStartIndex = int.Parse(commandParams[1]); 
                    int sortCount = int.Parse(commandParams[3]);
                    if (DataIsCorrect(sortCount, sortStartIndex))
                    {
                        Array.Sort(collection, sortStartIndex, sortCount);
                    }
                    
                    break;
                case "rollLeft":
                    int leftRollCount = int.Parse(commandParams[0]);
                    if (leftRollCount >= 0)
                    {
                        ArrayRoll("Left", leftRollCount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    
                    break;
                case "rollRight":
                    int rightRollCount = int.Parse(commandParams[0]);
                    if (rightRollCount >= 0)
                    {
                        ArrayRoll("Right", rightRollCount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }

                    break;
                case "end":
                    Console.WriteLine("[{0}]", string.Join(", ", collection));
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input parameters.");
                    break;
            }
        }

        private static bool DataIsCorrect(int count, int startIndex)
        {
            bool countCheck = count >= 0 && count <= collection.Length;
            bool indexCheck = startIndex >= 0 && startIndex < collection.Length;
            if (countCheck && indexCheck)
            {
                return true;
            }

            Console.WriteLine("Invalid input parameters.");
            return false;
        }

        private static string ConvertWhitespaceToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }

        private static void ArrayRoll(string direction, int count)
        {
            List<string> startArrayPart = new List<string>();
            List<string> newCollection = collection.ToList();
            switch (direction)
            {
                case "Left":
                    ////[1 2 3 4 5]
                    int leftIndex = RotateIndexLeft(count);
                    if (leftIndex != 0)
                    {
                        startArrayPart = newCollection.GetRange(0, leftIndex);
                        newCollection.RemoveRange(0, leftIndex);
                        newCollection.AddRange(startArrayPart);
                        collection = newCollection.ToArray();
                    }

                    break;
                case "Right":
                    //////[1 2 3 4 5]
                    int rightIndex = RotateIndexRight(count);
                    if (rightIndex != 0)
                    {
                        startArrayPart = newCollection.GetRange(0, rightIndex);
                        newCollection.RemoveRange(0, rightIndex);
                        newCollection.AddRange(startArrayPart);
                        collection = newCollection.ToArray();
                    }

                    break;
                default:
                    break;
            }
        }

        private static int RotateIndexRight(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            var index = 0;
            for (int i = 0; i < count; i++)
            {
                index--;
                if (index < 0)
                {
                    index = collection.Length - 1;
                }
            }

            return index;
        }

        private static int RotateIndexLeft(int count)
        {
            if (count == 0)
            {
                return 0;
            }

            var index = 0;
            for (int i = 0; i < count; i++)
            {
                index++;
                if (index > collection.Length - 1)
                {
                    index = 0;
                }
            }

            return index;
        }
    }
}