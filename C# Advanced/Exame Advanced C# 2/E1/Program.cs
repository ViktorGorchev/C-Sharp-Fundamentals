namespace E1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var data = new Dictionary<int, string>()
            {
                { 0, "zero" }, 
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" }
            };

            var stringToNumber = new Dictionary<string, string>()
            {
                { "zero", "0" }, 
                { "one", "1" },
                { "two", "2" },
                { "three", "3" },
                { "four", "4" },
                { "five", "5" },
                { "six", "6" },
                { "seven", "7" },
                { "eight", "8" },
                { "nine", "9" }
            };

            var numbers = 
                Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<string> numbersToSting = new List<string>();
            for (int i = 0; i < numbers.Count(); i++)
            {
                StringBuilder sb = new StringBuilder();
                string number = numbers[i];
                for (int j = 0; j < number.Length; j++)
                {
                    sb.Append(data[int.Parse(number[j].ToString())] + " ");
                }

                numbersToSting.Add(sb.ToString().Trim());
            }

            numbersToSting.Sort();

            List<string> sortedNumbers = new List<string>();
            for (int i = 0; i < numbersToSting.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                var subNumbers = numbersToSting[i].Split();
                for (int j = 0; j < subNumbers.Length; j++)
                {
                    sb.Append(stringToNumber[subNumbers[j]]);
                }

                sortedNumbers.Add(sb.ToString());
            }

            Console.WriteLine(string.Join(", ", sortedNumbers));
        }
    }
}
