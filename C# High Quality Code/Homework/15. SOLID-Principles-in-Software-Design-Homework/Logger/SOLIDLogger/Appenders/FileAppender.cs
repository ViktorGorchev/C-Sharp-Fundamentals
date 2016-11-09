namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Interfaces;

    public class FileAppender : Appender
    {
        /// <summary>
        /// Important: File path must be set by the property File after the class is Initialized! 
        /// File path cannot be null!
        /// </summary>
        /// <param name="formatter"></param>
        public FileAppender(ILayout formatter)
            : base(formatter)
        {
        }

        /// <summary>
        /// Property File must be set after the class is Initialized!
        /// </summary>
        public string File { get; set; }
       
        public override void Append(string message, LevelOfReport level, DateTime date)
        {
            if (this.File == null)
            {
                throw new AggregateException("File path cannot be null!");
            }

            if ((int)this.ReportLevel <= (int)level)
            {
                var writer = new StreamWriter(this.File, true);

                try
                {
                    string output = this.Formatter.Format(message, level, date);
                    writer.WriteLine(output);
                }
                catch (Exception up)
                {
                    throw up;
                }
                finally
                {
                    writer.Close();
                }
            }
        }
    }
}
