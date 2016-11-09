namespace TestLogger
{
    using ConsoleAppTest;

    using Logger;
    using Logger.Appenders;
    using Logger.Formatters;
    using Logger.Interfaces;

    public class LoggerMain
    {
        public static void Main()
        {
            ////Log 1
            ILayout simpleLayout1 = new SimpleLayout();
            IAppender consoleAppender1 = new ConsoleAppender(simpleLayout1);
            ILogger logger1 = new Logger(consoleAppender1);
            
            logger1.Error("Error parsing JSON.");
            logger1.Info(string.Format("User {0} successfully registered.", "Shoppe"));
            
            ////Log 2
            var simpleLayout2 = new SimpleLayout();
            var consoleAppender2 = new ConsoleAppender(simpleLayout2);
            var fileAppender2 = new FileAppender(simpleLayout2);
            fileAppender2.File = "log.txt";

            var logger2 = new Logger(consoleAppender2, fileAppender2);
            logger2.Error("Error parsing JSON.");
            logger2.Info(string.Format("User {0} successfully registered.", "Pesto"));
            logger2.Warn("Warning - missing files.");

            ////Log 3
            var xmlLayout = new XmlLayout();
            var consoleAppender3 = new ConsoleAppender(xmlLayout);
            var logger3 = new Logger(consoleAppender3);

            logger3.Fatal("mscorlib.dll does not respond");
            logger3.Critical("No connection string found in App.config");

            ////Log 4
            var simpleLayout4 = new SimpleLayout();
            var consoleAppender4 = new ConsoleAppender(simpleLayout4);
            consoleAppender4.ReportLevel = LevelOfReport.Error;

            var logger4 = new Logger(consoleAppender4);

            logger4.Info("Everything seems fine");
            logger4.Warn("Warning: ping is too high - disconnect imminent");
            logger4.Error("Error parsing request");
            logger4.Critical("No connection string found in App.config");
            logger4.Fatal("mscorlib.dll does not respond");

            ////Log 5
            var xmlLayout5 = new XmlLayout();
            var fileAppender5 = new FileAppender(xmlLayout5);
            fileAppender5.File = "log.txt";
            fileAppender5.ReportLevel = LevelOfReport.Error;

            var logger5 = new Logger(fileAppender5);

            logger5.Info("Everything seems fine");
            logger5.Warn("Warning: ping is too high - disconnect imminent");
            logger5.Error("Error parsing request");
            logger5.Critical("No connection string found in App.config");
            logger5.Fatal("mscorlib.dll does not respond");
        }
    }
}
