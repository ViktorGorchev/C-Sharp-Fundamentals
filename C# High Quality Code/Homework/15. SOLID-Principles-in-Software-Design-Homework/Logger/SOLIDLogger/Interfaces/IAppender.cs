namespace Logger.Interfaces
{
    using System;

    public interface IAppender
    {
        ILayout Formatter { get; set; }

        LevelOfReport ReportLevel { get; set; }

        void Append(string message, LevelOfReport level, DateTime date);
    }
}
