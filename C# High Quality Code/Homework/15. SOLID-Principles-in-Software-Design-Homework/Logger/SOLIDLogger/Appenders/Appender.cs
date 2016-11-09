namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        private ILayout formatter;

        protected Appender(ILayout formatter)
        {
            this.Formatter = formatter;
        }

        public ILayout Formatter
        {
            get
            {
                return this.formatter;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Formatter cannot be null");
                }

                this.formatter = value;
            }
        }

        public LevelOfReport ReportLevel { get; set; }

        public abstract void Append(string message, LevelOfReport level, DateTime date);
    }
}
