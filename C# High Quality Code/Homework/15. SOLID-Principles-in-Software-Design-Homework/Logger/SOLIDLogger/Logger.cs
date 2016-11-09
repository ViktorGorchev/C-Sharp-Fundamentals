namespace Logger
{
    using System;
    using Appenders;
    using Interfaces;

    public class Logger : ILogger
    {
        /// <summary>
        /// Loggs the error reports in a selected appender!
        /// </summary>
        /// <param name="appender">All available appenders can be used.</param>
        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }

        /// <summary>
        /// Loggs the error reports in a selected appender and in file!
        /// </summary>
        /// <param name="appender">All available appenders can be used.</param>
        /// <param name="appendToFile">Only FileAppender can be used! 
        /// If a different appender is set no error will be written in a file!</param>
        public Logger(IAppender appender, IAppender appendToFile)
        {
            this.Appender = appender;
            this.AppendToFile = appendToFile;
        }

        public IAppender Appender { get; set; }

        public IAppender AppendToFile { get; set; }
        
        public void Info(string msg)
        {
           this.Log(msg, LevelOfReport.Info);
        }

        public void Warn(string msg)
        {
            this.Log(msg, LevelOfReport.Warning); 
        }

        public void Error(string msg)
        {
            this.Log(msg, LevelOfReport.Error);
        }

        public void Critical(string msg)
        {
            this.Log(msg, LevelOfReport.Critical);
        }

        public void Fatal(string msg)
        {
            this.Log(msg, LevelOfReport.Fatal);
        }

        private void Log(string msg, LevelOfReport level)
        {
            var date = DateTime.Now;
            if (this.AppendToFile is FileAppender)
            {
                this.AppendToFile.Append(msg, level, date);
            }

            this.Appender.Append(msg, level, date);
        }
    }
}
