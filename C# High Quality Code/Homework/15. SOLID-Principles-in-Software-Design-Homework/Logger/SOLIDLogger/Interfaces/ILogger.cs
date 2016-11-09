namespace Logger.Interfaces
{
    public interface ILogger
    {
        IAppender Appender { get; set; }

        void Info(string msg);

        void Warn(string msg);

        void Error(string msg);

        void Critical(string msg);

        void Fatal(string msg);
    }
}
