using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Laptop_Shop
{
    public class BatteryForLaptop
    {
        private string battery;
        private double batteryLife;

        public BatteryForLaptop()
        {

        }

        public BatteryForLaptop(string battery, double batteryLife)
        {
            this.Battery = battery;
            this.BatteryLife = batteryLife;
        }
        public string Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.battery = value;
            }
        }
        public double BatteryLife
        {
            get
            {
                return this.batteryLife;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery life can't be less than 0!");
                }
                this.batteryLife = value;
            }
        }
       
    }
}
