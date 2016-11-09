namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout formatter)
            : base(formatter)
        {
        }

        public override void Append(string message, LevelOfReport level, DateTime date)
        {
            if ((int)this.ReportLevel <= (int)level)
            {
                string output = this.Formatter.Format(message, level, date);
                Console.WriteLine(output);
            }
        }
    }
}
