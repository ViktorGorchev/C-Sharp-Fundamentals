namespace MyTextTransformer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class TextTransformerMain
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "burp")
                {
                    break;
                }

                sb.Append(input);
            }
            ////(\$)([!-#(-~]+)(\$)|(\%)([!-#(-~]+)(\%)|(\&)([!-#(-~]+)(\&)|(\')([!-#(-~]+)(\')
            string inputTrimed = ConvertCToSpacesRegex(sb.ToString()).Trim();
            
            string patern = @"(\$)([!-#\(-~]+)(\$)|(\%)([!-#\(-~]+)(\%)|(\&)([!-#\(-~]+)(\&)|(\')([!-#\(-~]+)(\')";

            var mathches = Regex.Matches(inputTrimed, patern);

            Dictionary<string, int> weight = new Dictionary<string, int>();
            weight.Add("$", 1);
            weight.Add("%", 2);
            weight.Add("&", 3);
            weight.Add("'", 4);

            char newSymbol;
            StringBuilder resutString = new StringBuilder();
            foreach (Match match in mathches)
            {
                StringBuilder textSb = new StringBuilder(match.Captures[0].Value);
                textSb.Remove(textSb.Length - 1, 1);
                textSb.Remove(0, 1);
                string text = textSb.ToString();
                string specialSymbol = match.Captures[0].Value[0].ToString();
                
                for (int i = 0; i < text.Length; i++)
                {
                    char symbol = text[i];
                    if (i % 2 == 0)
                    {
                        newSymbol = (char)((int)symbol + weight[specialSymbol]);
                        resutString.Append(newSymbol);
                        continue;
                    }

                    newSymbol = (char)((int)symbol - weight[specialSymbol]);
                    resutString.Append(newSymbol);
                }

                resutString.Append(" ");
            }

            Console.WriteLine(resutString.ToString().Trim()); 
        }

        private static string ConvertCToSpacesRegex(string value)
        {
            value = Regex.Replace(value, @"\s+", " ");
            return value;
        }
    }
}