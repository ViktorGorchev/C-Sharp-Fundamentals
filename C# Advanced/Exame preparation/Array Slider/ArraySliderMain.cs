namespace MyArraySlider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Numerics;

    public class ArraySliderMain
    {
        private static List<BigInteger> data = new List<BigInteger>();
        private static int index = 0;

        public static void Main()
        {
            data = ConvertCToSpacesRegex(Console.ReadLine()).Split().Select(BigInteger.Parse).ToList();

            string command = ConvertCToSpacesRegex(Console.ReadLine());

            while (command != "stop")
            {
                var commandData = command.Split().ToArray();
                int offset = int.Parse(commandData[0]);
                string operation = commandData[1];
                int operand = int.Parse(commandData[2]);

                ExecuteCommand(offset, operation, operand);

                command = ConvertCToSpacesRegex(Console.ReadLine());
            }

            Console.WriteLine("[{0}]", string.Join(", ", data));
        }

        private static void ExecuteCommand(int offset, string operation, int operand)
        {
            index = GetIndex(offset);

            switch (operation)
            {
                case "+":
                    data[index] += operand;
                    break;
                case "-":
                    data[index] -= operand;
                    break;
                case "*":
                    data[index] *= operand;
                    break;
                case "/":
                    data[index] /= operand;
                    break;
                case "&":
                    data[index] &= operand;
                    break;
                case "|":
                    data[index] |= operand;
                    break;
                case "^":
                    data[index] ^= operand;
                    break;
                default:
                    break;
            }

            if (data[index] < 0)
            {
                data[index] = 0;
            }
        }

        private static int GetIndex(int offset)
        {
            int currentIndex = index;

            offset %= data.Count;
            if (offset < 0)
            {
                offset += data.Count;
            }

            int tempIndex = (currentIndex + offset) % data.Count;
            
            return tempIndex;
        }

        private static string ConvertCToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}