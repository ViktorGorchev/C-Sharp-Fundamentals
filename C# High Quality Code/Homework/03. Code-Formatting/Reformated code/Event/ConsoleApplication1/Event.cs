namespace EventsleApplication
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private readonly string title;
        private readonly string location;
        private DateTime date;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int eventByDate = this.date.CompareTo(other.date);
            int eventByTitle = this.title.CompareTo(other.title);

            int eventByLocation = this.location.CompareTo(other.location);
            if (eventByDate == 0)
            {
                if (eventByTitle == 0)
                {
                    return eventByLocation;
                }

                return eventByTitle;
            }

            return eventByDate;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);
            if (this.location != null && this.location != string.Empty)
            {
                toString.Append(" | " + this.location);
            }
            
            return toString.ToString();
        }
    }
}