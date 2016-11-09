using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _02_Laptop_Shop
{
    class Shop
    {
        static void Main()
        {
            Laptop descriptionLaptop = new Laptop();
            descriptionLaptop.Model = "Lenovo Yoga 2 Pro";
            descriptionLaptop.Manufacturer = "Lenovo";
            descriptionLaptop.Processor = "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)";
            descriptionLaptop.Ram = "8 GB";
            descriptionLaptop.GraphicsCard = "Intel HD Graphics 4400";
            descriptionLaptop.Hdd = "128GB SSD";
            descriptionLaptop.Screen = @"13.3"" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display";
            descriptionLaptop.Battery.Battery = "Li-Ion, 4-cells, 2550 mAh";
            descriptionLaptop.Battery.BatteryLife = 4.5;
            descriptionLaptop.Price = 2259.00;
            Console.WriteLine(descriptionLaptop);

            Laptop mandatoryProperties = new Laptop();
            mandatoryProperties.Model = "HP 250 G2";
            mandatoryProperties.Price = 699.00;
            mandatoryProperties.ShortData();
        }
    }
}
