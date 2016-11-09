namespace ConsoleApplication1
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            StringBuilder input = new StringBuilder();

            string inputLine = Console.ReadLine();
            while (inputLine != "END")
            {
                input.Append(inputLine);
                inputLine = Console.ReadLine();
            }

            string pattern = @"[<][a]\s*([!-=?-~\s]*)\s+[herf]+\s*[=]\s*(.*?)[>]";
            var matches = Regex.Matches(input.ToString(), pattern);

            StringBuilder result = new StringBuilder();
            foreach (Match match in matches)
            {
                string htmlData = match.Groups[2].Value;
                if (htmlData[0] == '"' || htmlData[0] == '\'')
                {
                    char startChar = htmlData[0];
                    htmlData = htmlData.Remove(0, 1);
                    var temp = htmlData.Split(startChar);
                    htmlData = temp[0];
                }
                else
                {
                    var temp2 = htmlData.Split();
                    htmlData = temp2[0];
                }

                result.AppendLine(htmlData);
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }
}
