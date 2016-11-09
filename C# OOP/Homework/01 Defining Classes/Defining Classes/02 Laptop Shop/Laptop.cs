using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _02_Laptop_Shop
{
    public class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;        
        private double price;
        private BatteryForLaptop battery;


        public Laptop()
        {
            battery = new BatteryForLaptop();
        }

        public Laptop(string model, string manufacturer, string processor, string ram, string graphicsCard, 
            string hdd, string screen, BatteryForLaptop batery, double price)
        {
            this.Model = model; 
            this.Manufacturer = manufacturer; 
            this.Processor = processor; 
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            Battery = batery;
            this.Price = price;
            
        }
        public Laptop(string model, double price)
        {
            this.Model = model;
            this.Price = price;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model is mandatory!");
                }
                this.model = value;
            }
        }
        public string Manufacturer 
        {
            get 
            {
                return this.manufacturer;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.manufacturer = value;
            }
        }
        public string Processor 
        {
            get 
            {
                return this.processor;
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.processor = value;
            }
        }
        public string Ram 
        {
            get 
            {
                return this.ram;
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.ram = value;
            }
        }
        public string GraphicsCard 
        {
            get 
            {
                return this.graphicsCard;
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.graphicsCard = value;
            }
        }
        public string Hdd 
        {
            get 
            {
                return this.hdd;
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.hdd = value;
            }
        }
        public string Screen 
        {
            get 
            {
                return this.screen;
            }
            set 
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Invalid input!");                   
                }
                this.screen = value;
            }
        }
        public BatteryForLaptop Battery 
        {
            get 
            {
                return this.battery;
            }
            set 
            {
                this.battery = value;
            }
        }
        public double Price 
        {
            get 
            {
                return this.price;
            }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price is mandatory and must be more than 0!");
                }
                this.price = value;
            }
        }
        public override string ToString()
        {
            return string.Format("Sample laptop description (full):" + Environment.NewLine +
               "| model | " + this.Model.PadRight(15, ' ') + Environment.NewLine +
               "| manufacturer | " + this.Manufacturer + Environment.NewLine +
               "| processor | " + this.Processor + Environment.NewLine +
               "| RAM | " + this.Ram + Environment.NewLine +
               "| graphics card | " + this.GraphicsCard + Environment.NewLine +
               "| HDD |" + this.Hdd + Environment.NewLine +
               "| screen | " + this.Screen + Environment.NewLine +
               "| battery | " + this.Battery.Battery + Environment.NewLine +
               "| battery  life | " + this.Battery.BatteryLife + " hours" + Environment.NewLine +
               string.Format("| price | {0:c}", this.Price) + Environment.NewLine);
        }
        public void ShortData() 
        {
            Console.WriteLine("Sample laptop description (mandatory properties only):" + Environment.NewLine +
               "| model | " + this.Model + Environment.NewLine +
               string.Format("| price | {0:c}", this.Price));
        }      
    }
}
