namespace Theatre.Contracts
{
    using System.Collections.Generic;

    using Theatre.Models;

    public interface IDataBase
    {
        Dictionary<string, List<TheatrePerformance>> Data { get; set; }
    }
}
