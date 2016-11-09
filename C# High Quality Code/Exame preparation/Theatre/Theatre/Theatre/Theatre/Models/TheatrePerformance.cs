namespace Theatre.Models
{
    using System;
    
    public class TheatrePerformance
    {
        private string theatreName;
        private string play;
        private decimal price;

        public TheatrePerformance(string theatreName, string play, DateTime date, TimeSpan duration, decimal price)
        {
            this.TheatreName = theatreName;
            this.Play = play;
            this.Date = date;
            this.Duration = duration;
            this.Price = price;
        }

        public string TheatreName
        {
            get
            {
                return this.theatreName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Theatre name cannot be null or empty!");
                }

                this.theatreName = value;
            }
        }

        public string Play
        {
            get
            {
                return this.play;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new AggregateException("Play name cannot be null or empty!");
                }

                this.play = value;
            }
        }

        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new AggregateException("Price cannot be a negative number!");
                }

                this.price = value;
            }
        }
        
        public override string ToString()
        {
            string result = string.Format(
                "TheatrePerformance(Theatre name: {0}; play: {1}; date: {2}, duration: {3}, price: {4})", 
                this.TheatreName, 
                this.Play, 
                this.Date.ToString("dd.MM.yyyy HH:mm"), 
                this.Duration.ToString("HH':'mm"), 
                this.Price.ToString("f2"));
            return result;
        }
    }
}