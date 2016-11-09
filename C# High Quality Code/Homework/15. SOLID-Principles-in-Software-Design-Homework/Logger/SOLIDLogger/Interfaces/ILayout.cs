namespace Logger.Interfaces
{
    using System;

    public interface ILayout
    {
        string Format(string msg, LevelOfReport level, DateTime date);
    }
}
