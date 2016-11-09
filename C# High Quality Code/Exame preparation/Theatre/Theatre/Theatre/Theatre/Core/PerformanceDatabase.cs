namespace Theatre.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Theatre.Contracts;
    using Theatre.Exceptions;
    using Theatre.Models;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private IDataBase dataBase;

        public PerformanceDatabase(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }

        public void AddTheatre(string theatre)
        {
            if (this.dataBase.Data.ContainsKey(theatre))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.dataBase.Data[theatre] = new List<TheatrePerformance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var teathresList = new List<string>(this.dataBase.Data.Keys);
            teathresList.Sort();
            return teathresList;
        }
        
        public void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.dataBase.Data.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performance = this.dataBase.Data[theatreName];

            var endTime = startDateTime + duration;
            if (this.OverlapDuration(performance, startDateTime, endTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var theatrePerformance = new TheatrePerformance(theatreName, performanceTitle, startDateTime, duration, price);
            performance.Add(theatrePerformance);
        }
        
        public IEnumerable<TheatrePerformance> ListAllPerformances()
        {
            var theatres = new List<string>(this.dataBase.Data.Keys);
            theatres.Sort();

            List<TheatrePerformance> allPerformances = new List<TheatrePerformance>();
            foreach (var theatre in theatres)
            {
                allPerformances.AddRange(this.dataBase.Data[theatre].OrderBy(p => p.TheatreName).ThenBy(p => p.Date));
            }

            return allPerformances;
        }

        public IEnumerable<TheatrePerformance> ListPerformances(string theatreName)
        {
            if (!this.dataBase.Data.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performancesList = this.dataBase.Data[theatreName].OrderBy(p => p.TheatreName).ThenBy(p => p.Date);
            return performancesList;
        }

        private bool OverlapDuration(IEnumerable<TheatrePerformance> performances, DateTime startDateTime, DateTime endTime)
        {
            foreach (var performance in performances)
            {
                var performanceStartDate = performance.Date;

                var performanceEndDateTime = performance.Date + performance.Duration;

                var overlapPerformances = (performanceStartDate <= startDateTime && startDateTime <= performanceEndDateTime) || 
                    (performanceStartDate <= endTime && endTime <= performanceEndDateTime) || 
                    (startDateTime <= performanceStartDate && performanceStartDate <= endTime) || 
                    (startDateTime <= performanceEndDateTime && performanceEndDateTime <= endTime);
                if (overlapPerformances)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
