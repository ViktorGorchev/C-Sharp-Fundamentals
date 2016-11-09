// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Engine.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Theatre.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Theatre.Contracts;
    using Theatre.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IRenderer renderer;
        private readonly IPerformanceDatabase dataBase;

        public Engine(IReader reader, IRenderer renderer, IPerformanceDatabase dataBase)
        {
            this.reader = reader;
            this.renderer = renderer;
            this.dataBase = dataBase;
        }

        public void Run()
        {
            while (true)
            {
                string inputCommand = this.reader.Read();
                
                if (inputCommand == null)
                {
                    return;
                }

                if (inputCommand == string.Empty)
                {
                    continue;
                }
                
                try
                {
                    string[] commandParams = this.SplitCommand(inputCommand);

                    this.ExecuteCommand(commandParams);
                }
                catch (Exception ex)
                {
                    this.renderer.Render(string.Format("Error: " + ex.Message)); 
                }
            }
        }

        private string[] SplitCommand(string inputCommand)
        {
            string[] commandParams = inputCommand.Trim().Split(
                        new[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < commandParams.Length; i++)
            {
                commandParams[i] = commandParams[i].Trim();
            }

            return commandParams;
        }

        private void ExecuteCommand(string[] commandParams)
        {
            string command = commandParams[0];
            var commandInfo = commandParams.Skip(1).ToArray();
            string commandResult;
            
            switch (command)
            {
                case "AddTheatre":
                    commandResult = this.ExecuteAddTheatreCommand(commandInfo);
                    break;
                case "PrintAllTheatres":
                    commandResult = this.ExecutePrintAllTheatresCommand();
                    break;
                case "AddPerformance":
                    commandResult = this.ExecuteAddPerformanceCommand(commandInfo);
                    break;
                case "PrintAllPerformances":
                    commandResult = this.ExecutePrintAllPerformancesCommand();
                    break;
                case "PrintPerformances":
                    commandResult = this.ExecutePrintPerformancesCommand(commandInfo);
                    break;
                case "exit":
                    commandResult = null;
                    Environment.Exit(0);
                    break;
                default:
                    commandResult = "Invalid command!";
                    break;
            }

            this.PrintCommandResult(commandResult);
        }

        private string ExecutePrintPerformancesCommand(string[] commandInfo)
        {
            string commandResult = "No performances";
            string theatre = commandInfo[0];
            
            var performances = this.dataBase.ListPerformances(theatre).Select(
                p =>
                {
                    string startTime = p.Date.ToString("dd.MM.yyyy HH:mm");
                    return string.Format("({0}, {1})", p.Play, startTime);
                }).ToList();

            if (performances.Any())
            {
                commandResult = string.Join(", ", performances);
            }

            return commandResult;
        }

        private void PrintCommandResult(string commandResult)
        {
            this.renderer.Render(commandResult);
        }

        private string ExecuteAddPerformanceCommand(string[] commandInfo)
        {
            string theatreName = commandInfo[0];
            string performanceTitle = commandInfo[1];
            DateTime startDateTime = DateTime.ParseExact(commandInfo[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(commandInfo[3]);
            decimal price = decimal.Parse(commandInfo[4], NumberStyles.Float);

            this.dataBase.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);

            return "Performance added";
        }

        private string ExecuteAddTheatreCommand(string[] commandInfo)
        {
            string theatreName = commandInfo[0];
            this.dataBase.AddTheatre(theatreName);

            return "Theatre added";
        }

        private string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = this.dataBase.ListTheatres().Count();
            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();

                for (int i = 0; i < theatresCount; i++)
                {
                    this.dataBase.ListTheatres().Skip(i).ToList().ForEach(t => resultTheatres.AddLast(t));
                    foreach (var t in this.dataBase.ListTheatres().Skip(i + 1))
                    {
                        resultTheatres.Remove(t);
                    }
                }

                return string.Join(", ", resultTheatres);
            }

            return "No theatres";
        }

        private string ExecutePrintAllPerformancesCommand()
        {
            var result = string.Empty;
            var performances = new List<TheatrePerformance>(this.dataBase.ListAllPerformances());

            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    var sb = new StringBuilder();
                    sb.Append(result);
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }

                    string date = performances[i].Date.ToString("dd.MM.yyyy HH:mm");
                    sb.AppendFormat("({0}, {1}, {2})", performances[i].Play, performances[i].TheatreName, date);
                    result = sb + string.Empty;
                }

                return result;
            }

            return "No performances";
        }
    }
}
