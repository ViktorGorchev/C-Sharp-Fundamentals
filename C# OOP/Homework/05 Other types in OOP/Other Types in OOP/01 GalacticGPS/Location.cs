using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_GalacticGPS
{
    struct Location
    {
        private const double LatitudeMax = 90;
        private const double LatitudeMin = -90;

        private const double LongitudeMax = 180;
        private const double LongitudeMin = -180;

        private double latitude;
        private double longitude;
        private Planet planet;
        
        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.planet = planet;
        }
       
  

        public double Latitude
        {
            get { return this.latitude; }
            set
            {
                if (value > LatitudeMax || value < LatitudeMin)
                {
                    throw new ArgumentOutOfRangeException("Invalid latitude input!");
                }
                this.latitude = value;
            }
        }

        public double Longitude
        {
            get { return this.longitude; }
            set
            {
                if (value > LongitudeMax || value < LongitudeMin)
                {
                    throw new ArgumentOutOfRangeException("Invalid longitude input!");
                }
                this.longitude = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.planet);
        }
    }
}
