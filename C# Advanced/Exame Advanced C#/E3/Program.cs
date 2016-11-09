namespace E3
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            var data = new Dictionary<string, string>()
            {
                { "aa", "0"}, { "aba", "1"}, { "bcc", "2"}, { "cc", "3"}, { "cdc", "4"}
            };
            
            string pattern = @"(aa)*(aba)*(bcc)*(cc)*(cdc)*";

            string input = Console.ReadLine();

            StringBuilder quinaryString = new StringBuilder();
            var mstches = Regex.Matches(input, pattern);
            
            foreach (Match match in mstches)
            {
                foreach (var capture in match.Groups)
                {
                    if (!data.ContainsKey(capture.ToString()))
                    {
                        continue;
                    }

                    quinaryString.Append(data[capture.ToString()]);
                }
            }

            ulong quinary = ulong.Parse(quinaryString.ToString());

            ulong number = 0;
            ulong result = 0;
            int count = 1;
            for (int i = quinaryString.Length - 1; i >= 0; i--)
            {
                number = quinary % 10;
                quinary /= 10;

                if (i == quinaryString.Length - 1)
                {
                    result += (ulong)number;
                    continue;
                }

                result += number * (ulong)Math.Pow(5, count);
                count++;
            }

            Console.WriteLine(result);
        }
    }
}