namespace Theatre.Core
{
    using System.Collections.Generic;

    using Theatre.Contracts;
    using Theatre.Models;

    public class DataBase : IDataBase
    {
        public DataBase()
        {
            this.Data = new Dictionary<string, List<TheatrePerformance>>();
        }

        public Dictionary<string, List<TheatrePerformance>> Data { get; set; }
    }
}