using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _03_PC_Catalog
{
    class Catalog
    {
        static void Main()
        {
            Computer objectOne = new Computer();
            objectOne.Name = "HP";
            objectOne.Price = 100.50;
            objectOne.Parts.Motherboard = "ASUS";
            objectOne.Parts.MotherboardPrice = 20;
            objectOne.Parts.GraphicsCard = "Ati";
            objectOne.Parts.GraphicsCardPrice = 30;
            objectOne.Parts.Processor = "AMD";
            objectOne.Parts.ProcessorPrice = 50.50;
                       
            Computer objectTwo = new Computer();
            objectTwo.Name = "MAC";
            objectTwo.Price = 1000;
            objectTwo.Parts.GraphicsCard = "llkjj";
    
            Computer objectThree = new Computer();
            objectThree.Name = "Samsung";
            objectThree.Parts.Motherboard = "ASUS";
            objectThree.Parts.MotherboardPrice = 100;
            objectThree.Parts.GraphicsCard = "GeForce";
            objectThree.Parts.GraphicsCardPrice = 150;
            objectThree.Parts.Processor = "intel";
            objectThree.Parts.ProcessorPrice = 250.50;

            double[] sortingArray = new double[3];
            sortingArray[0] = objectOne.Parts.ProcessorPrice + objectOne.Parts.MotherboardPrice + objectOne.Parts.GraphicsCardPrice;
            sortingArray[1] = objectTwo.Price;
            sortingArray[2] = objectThree.Parts.ProcessorPrice + objectThree.Parts.MotherboardPrice + objectThree.Parts.GraphicsCardPrice;
            Array.Sort(sortingArray);

            foreach (var item in sortingArray)
            {
                if (item == objectOne.Parts.ProcessorPrice + objectOne.Parts.MotherboardPrice + objectOne.Parts.GraphicsCardPrice)
                {
                    objectOne.PrintFullData();                   
                }
                else if (item == objectTwo.Price)
                {
                    objectTwo.PrintNameAndPrice();                    
                }
                else
                {
                    objectThree.PrintNameAndCmponents();
                }
            }


        }
    }
}
