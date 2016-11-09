namespace EventsleApplication
{
    using System.Text;

    public class Messages
    {
        private static StringBuilder output = new StringBuilder();

        public void EventAdded()
        {
            output.Append("Event added\n");
        }

        public void EventDeleted(int removedEvents)
        {
            if (removedEvents == 0)
            {
                this.NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} Events deleted\n", removedEvents);
            }
        }

        public void NoEventsFound()
        {
            output.Append("No Events found\n");
        }

        public void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.Append(eventToPrint + "\n");
            }
        }
    }
}
