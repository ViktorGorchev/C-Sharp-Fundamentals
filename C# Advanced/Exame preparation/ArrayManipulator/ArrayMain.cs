namespace ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class ArrayMain
    {
        private static readonly List<int> NumbersList = new List<int>();
        
        public static void Main()
        {
            int count = 0;
            while (true)
            {
                var imputLine = Console.ReadLine();
                var input = imputLine.Split();
                if (count == 0)
                {
                    foreach (var number in input)
                    {
                        NumbersList.Add(int.Parse(number));
                    }

                    count++;
                    continue;
                }

                string result = ExecuteCommand(input);
                if (result != null)
                {
                    Console.WriteLine(result);
                }

                count++;
            }
        }

        private static string ExecuteCommand(string[] input)
        {
            var command = input[0];
            var commandParams = input.Skip(1).ToArray();
            string operationResult = null;

            switch (command.ToLower())
            {
                case "exchange":
                    operationResult = Exchange(int.Parse(commandParams[0]));
                    break;
                case "max":
                    operationResult = FindMax(commandParams[0]);
                    break;
                case "min":
                    operationResult = FindMin(commandParams[0]);
                    break;
                case "first":
                    int elementsCount = int.Parse(commandParams[0]);
                    string elementsType = commandParams[1];
                    operationResult = FirstElements(elementsType, elementsCount);
                    break;
                case "last":
                    int lastElementsCount = int.Parse(commandParams[0]);
                    string lastElementsType = commandParams[1];
                    operationResult = LastElements(lastElementsType, lastElementsCount);
                    break;
                case "end":
                    Console.WriteLine("[{0}]", string.Join(", ", NumbersList));
                    Environment.Exit(0);
                    break;
                default:
                    operationResult = "invalid command";
                    break;
            }

            return operationResult;
        }

        private static string LastElements(string lastElementsType, int lastElementsCount)
        {
            if (lastElementsCount > NumbersList.Count)
            {
                return "Invalid count";
            }

            switch (lastElementsType.ToLower())
            {
                case "even":
                    var elements = NumbersList.Where(x => x % 2 == 0).ToList();
                    if (elements.Count == 0)
                    {
                        return "[]";
                    }

                    if (elements.Count < lastElementsCount)
                    {
                        return string.Format("[{0}]", string.Join(", ", elements));
                    }

                    return string.Format(
                        "[{0}]", 
                        string.Join(", ", elements.GetRange(elements.Count - lastElementsCount, lastElementsCount)));
                case "odd":
                    var elementsOdd = NumbersList.Where(x => x % 2 != 0).ToList();
                    if (elementsOdd.Count == 0)
                    {
                        return "[]";
                    }

                    if (elementsOdd.Count < lastElementsCount)
                    {
                        return string.Format("[{0}]", string.Join(", ", elementsOdd));
                    }

                    return string.Format(
                        "[{0}]",
                        string.Join(", ", elementsOdd.GetRange(elementsOdd.Count - lastElementsCount, lastElementsCount)));
                default:
                    return "Type not supported!";
            }
        }

        private static string FirstElements(string elementsType, int elementsCount)
        {
            if (elementsCount > NumbersList.Count)
            {
                return "Invalid count";
            }

            switch (elementsType.ToLower())
            {
                case "even":
                    var elements = NumbersList.Where(x => x % 2 == 0).ToList();
                    if (elements.Count == 0)
                    {
                        return "[]";
                    }

                    if (elements.Count < elementsCount)
                    {
                        return string.Format("[{0}]", string.Join(", ", elements));
                    }

                    return string.Format("[{0}]", string.Join(", ", elements.GetRange(0, elementsCount)));
                case "odd":
                    var elementsOdd = NumbersList.Where(x => x % 2 != 0).ToList();
                    if (elementsOdd.Count == 0)
                    {
                        return "[]";
                    }

                    if (elementsOdd.Count < elementsCount)
                    {
                        return string.Format("[{0}]", string.Join(", ", elementsOdd));
                    }

                    return string.Format("[{0}]", string.Join(", ", elementsOdd.GetRange(0, elementsCount)));
                default:
                    return "Type not supported!";
            }
        }

        private static string FindMax(string typeOfMaxNumber)
        {
            switch (typeOfMaxNumber.ToLower())
            {
                case "even":
                    int maxNumber;
                    try
                    {
                        maxNumber = NumbersList.Where(x => x % 2 == 0).Max();
                    }
                    catch (Exception)
                    {
                        return "No matches";
                    }

                    int index = NumbersList.FindLastIndex(x => x == maxNumber);
                    
                    return index.ToString();
                case "odd":
                    int maxOddNumber;
                    try
                    {
                        maxOddNumber = NumbersList.Where(x => x % 2 != 0).Max();
                    }
                    catch (Exception)
                    {
                        return "No matches";
                    }

                    int indexOddNumber = NumbersList.FindLastIndex(x => x == maxOddNumber);

                    return indexOddNumber.ToString();
                default:
                    return "Type not supported!";
            }
        }

        private static string FindMin(string typeOfMaxNumber)
        {
            switch (typeOfMaxNumber.ToLower())
            {
                case "even":
                    int maxNumber;
                    try
                    {
                        maxNumber = NumbersList.Where(x => x % 2 == 0).Min();
                    }
                    catch (Exception)
                    {
                        return "No matches";
                    }

                    int index = NumbersList.FindLastIndex(x => x == maxNumber);

                    return index.ToString();
                case "odd":
                    int maxOddNumber;
                    try
                    {
                        maxOddNumber = NumbersList.Where(x => x % 2 != 0).Min();
                    }
                    catch (Exception)
                    {
                        return "No matches";
                    }

                    int indexOddNumber = NumbersList.FindLastIndex(x => x == maxOddNumber);

                    return indexOddNumber.ToString();
                default:
                    return "Type not supported!";
            }
        }

        private static string Exchange(int index)
        {
            if (index > NumbersList.Count - 1 || index < 0)
            {
                return "Invalid index";
            }

            if (index == NumbersList.Count - 1)
            {
                return null;
            }

            var range = NumbersList.GetRange(0, index + 1);
            NumbersList.AddRange(range);
            NumbersList.RemoveRange(0, index + 1);

            return null;
        }
    }
}