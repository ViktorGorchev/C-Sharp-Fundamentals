using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_PC_Catalog
{
    public class Components
    {
        private string processor; 
        private double processorPrice;
        private string graphicsCard;
        private double graphicsCardPrice;
        private string motherboard;
        private double motherboardPrice;

        public Components()
        {

        }
        public Components( string processor, double processorPrice,string graphicsCard, 
            double graphicsCardPrice, string motherboard, double motherboardPrice)
        {
            this.Processor = processor;
            this.ProcessorPrice = processorPrice;
            this.GraphicsCard = graphicsCard;
            this.GraphicsCardPrice = graphicsCardPrice;
            this.Motherboard = motherboard;
            this.MotherboardPrice = motherboardPrice;
           
        }
        public string Processor 
        {
            get 
            {
                return this.processor;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.processor = value;
            }
        }
        public double ProcessorPrice 
        {
            get 
            {
                return this.processorPrice;
            }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Enter valid price!");
                }
                this.processorPrice = value;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.graphicsCard = value;
            } 
        }
        public double GraphicsCardPrice 
        {
            get
            {
                return this.graphicsCardPrice;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Enter valid price!");
                }
                this.graphicsCardPrice = value;
            } 
        }
        public string Motherboard 
        {
            get
            {
                return this.motherboard;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.motherboard = value;
            } 
        }
        public double MotherboardPrice 
        {
            get
            {
                return this.motherboardPrice;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Enter valid price!");
                }
                this.motherboardPrice = value;
            } 
        }
    }
}
