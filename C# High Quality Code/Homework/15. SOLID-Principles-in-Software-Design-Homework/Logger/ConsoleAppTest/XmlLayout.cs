namespace ConsoleAppTest
{
    using System;
    using System.Text;
    using Logger;
    using Logger.Interfaces;

    public class XmlLayout : ILayout
    {
        public string Format(string msg, LevelOfReport level, DateTime date)
        {
            var output = new StringBuilder();
            output.AppendLine("<log>");
            output.AppendLine("<date>" + date + "</date>");
            output.AppendLine("<level>" + level + "</level>");
            output.AppendLine("<message>" + msg + "</message>");
            output.Append("</log>");

            return output.ToString();
        }
    }
}
