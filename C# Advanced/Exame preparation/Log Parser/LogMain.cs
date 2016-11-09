namespace MyLogParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class LogMain
    {
        public static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, List<string>>>();
            string pattern = @"{""Project"": \[\""(.*?)\""\], ""Type"": \[\""(.*?)\""\], ""Message"": \[\""(.*?)\""\]}";

            string input = Console.ReadLine();

            while (input != "END")
            {
                var matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    string project = match.Groups[1].Value;
                    string type = match.Groups[2].Value;
                    string message = match.Groups[3].Value;

                    if (!data.ContainsKey(project))
                    {
                        data[project] = new Dictionary<string, List<string>>();
                    }

                    if (!data[project].ContainsKey(type))
                    {
                        data[project].Add("Critical", new List<string>());
                        data[project].Add("Warning", new List<string>());
                    }

                    data[project][type].Add(message);
                }
                
                input = Console.ReadLine();
            }
            

            StringBuilder report = new StringBuilder();
            foreach (var project in data.OrderByDescending(x => x.Value.Values.Sum(e => e.Count)).ThenBy(k => k.Key))
            {
                report.AppendLine(project.Key + ":");
                report.AppendLine("Total Errors: " + project.Value.Values.Sum(x => x.Count));
                report.AppendLine(
                    "Critical: " + project.Value.Where(x => x.Key == "Critical").Sum(x => x.Value.Count));
                report.AppendLine(
                   "Warnings: " + project.Value.Where(x => x.Key == "Warning").Sum(x => x.Value.Count));
                foreach (var warning in project.Value)
                {
                    report.AppendLine(warning.Key + " Messages:");
                    if (warning.Value.Count == 0)
                    {
                        report.AppendLine("--->None");
                        continue;
                    }

                    warning.Value.Sort();
                    foreach (var message in warning.Value.OrderBy(x => x.Length))
                    {
                        report.AppendLine("--->" + message);
                    }
                }

                report.AppendLine();
            }
            
            Console.WriteLine(report.ToString().TrimEnd('\r', '\n'));
        }
    }
}