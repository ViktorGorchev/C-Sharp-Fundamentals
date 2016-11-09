using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PC_Catalog
{
    public class Computer
    {
        private string name;
        private double price;
        private Components parts;
       
        public Computer()
        {
            Parts = new Components();
        }
        public Computer(string name, double price, Components components)
        {
            this.Name = name;
            this.Price = price;
            Parts = components;
        }
        public Computer(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name 
        {
            get 
            {
                return this.name;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Enter name!");
                }
                this.name = value;
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
                    throw new ArgumentException("Enter valid price!");
                }
                this.price = value;
            }            
        }
        public Components Parts
        { 
            get 
            {
                return this.parts;
            }
            set 
            {
                this.parts = value;
            }
        }
        public void PrintFullData()
        {
            Console.WriteLine("Computer name: " + this.Name + Environment.NewLine + "Computer price: {0:c}", this.Price);
            Console.WriteLine("Processor: " + parts.Processor + " Price: {0:c}", parts.ProcessorPrice);
            Console.WriteLine("Graphics card: " + parts.GraphicsCard + " Price: {0:c}", parts.GraphicsCardPrice);
            Console.WriteLine("Motherboard: "+ parts.Motherboard + " Price: {0:c}", parts.MotherboardPrice);
            Console.WriteLine("Total computer price: {0:c}", (parts.ProcessorPrice + parts.MotherboardPrice + parts.GraphicsCardPrice) + Environment.NewLine);
        } 

        public void PrintNameAndPrice()
        {
            Console.WriteLine("Computer name: " + this.Name + Environment.NewLine + "Computer price: {0:c}", this.Price + Environment.NewLine);
        }

        public void PrintNameAndCmponents() 
        {
            Console.WriteLine("Computer name: " + this.Name);
            Console.WriteLine("Processor: " + parts.Processor + " Price: {0:c}", parts.ProcessorPrice);
            Console.WriteLine("Graphics card: " + parts.GraphicsCard + " Price: {0:c}", parts.GraphicsCardPrice);
            Console.WriteLine("Motherboard: " + parts.Motherboard + " Price: {0:c}", parts.MotherboardPrice);
            Console.WriteLine("Total computer price: {0:c}", (parts.ProcessorPrice + parts.MotherboardPrice + parts.GraphicsCardPrice) + Environment.NewLine);
        }
    }
}
 